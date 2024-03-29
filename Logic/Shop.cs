﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class Shop : IShop, IObserver<IWeapon>
    {
        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler<IWeaponDTO> OnWeaponChanged;
        public event EventHandler<IWeaponDTO> OnWeaponRemoved;
        public event EventHandler TransactionFailed;
        public event EventHandler<List<IWeaponDTO>> TransactionSucceeded;

        private IWarehouse warehouse;
        private IDisposable unsubscriber;

        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            warehouse.PriceChange += OnPriceChanged;
            warehouse.TransactionFailed += OnTransactionFailed;
            warehouse.TransactionSucceeded += OnTransactionSucceeded;
            warehouse.Subscribe(this);
        }

        private void OnTransactionSucceeded(object? sender, List<IWeapon> e)
        {
            warehouse.RemoveWeapons(e);
            EventHandler<List<IWeaponDTO>> handler = TransactionSucceeded;
            List<IWeaponDTO> soldWeapons = new List<IWeaponDTO>();

            foreach (IWeapon weapon in e)
            {
                WeaponDTO weaponDTO = new WeaponDTO();
                weaponDTO.Type = weapon.Type.ToString();
                weaponDTO.Id = weapon.Id;
                weaponDTO.Name = weapon.Name;
                weaponDTO.Origin = weapon.Origin.ToString();
                weaponDTO.Price = weapon.Price;

                soldWeapons.Add(weaponDTO);
            }

            handler?.Invoke(this, soldWeapons);
        }

        private void OnTransactionFailed(object? sender, EventArgs e)
        {
            EventHandler handler = TransactionFailed;
            handler?.Invoke(this, e);
        }

        public List<IWeaponDTO> GetWeapons()
        {
            List<IWeaponDTO> availableWeapons = new List<IWeaponDTO>();

            foreach (IWeapon weapon in warehouse.Stock)
            {
                var dto = new WeaponDTO();
                dto.Name = weapon.Name;
                dto.Price = weapon.Price;
                dto.Id = weapon.Id;
                dto.Type = weapon.Type.ToString();
                dto.Origin = weapon.Origin.ToString();

                availableWeapons.Add(dto);
            }

            return availableWeapons;
        }

        public async Task Sell(List<IWeaponDTO> weapons)
        {
            List<Guid> weaponIds = new List<Guid>();

            foreach (WeaponDTO weapon in weapons) 
                weaponIds.Add(weapon.Id);

            List<IWeapon> weaponsDataLayer = warehouse.GetWeaponsByID(weaponIds);

            foreach (WeaponDTO weapon in weapons)
            {
                IWeapon wp = weaponsDataLayer.Find(x => x.Id == weapon.Id);
                if (wp != null)
                {
                    wp.Price = weapon.Price;
                }
            }
            await warehouse.TryBuying(weaponsDataLayer);
        }

        private void OnPriceChanged(object sender, Data.PriceChangeEventArgs e) 
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new Logic.PriceChangeEventArgs(e.Id, e.Price));
        }

        public async Task SendMessageAsync(string mesg)
        {
            await warehouse.SendAsync(mesg);
        }

        public void OnCompleted()
        {
            this.Unsunscribe();
        }

        public void OnError(Exception error)
        {
            //throw new NotImplementedException();
        }

        public void OnNext(IWeapon value)
        {
            var dto = new WeaponDTO();
            dto.Price = value.Price;
            dto.Id = value.Id;
            dto.Name = value.Name;
            dto.Type = value.Type.ToString();
            dto.Origin = value.Origin.ToString();

            if (value.Price < -0.01f && value.Name == "" && value.Type == WeaponType.Deleted && value.Origin == CountryOfOrigin.Deleted)
                OnWeaponRemoved?.Invoke(this, dto);
            else
                OnWeaponChanged?.Invoke(this, dto);
        }

        private void Unsunscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
