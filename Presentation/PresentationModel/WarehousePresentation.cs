using System;
using System.Collections.Generic;
using System.Text;
using Logic;

namespace PresentationModel
{
    public class WarehousePresentation
    {
        private IShop Shop { get; set; }

        public WarehousePresentation(IShop shop)
        {
            Shop = shop;
            Shop.PriceChanged += OnPriceChanged;
        }
        private void OnPriceChanged(object sender, Logic.PriceChangeEventArgs e)
        {
            EventHandler<PresentationModel.PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new PresentationModel.PriceChangeEventArgs(e.Id, e.Price));
        }

        public List<WeaponPresentation> GetWeapons()
        {
            List<WeaponPresentation> weapons = new List<WeaponPresentation>();
            foreach (IWeaponDTO weapon in Shop.GetWeapons())
            {
                weapons.Add(new WeaponPresentation(weapon.Name, weapon.Price, weapon.Id, weapon.Origin, weapon.Type));
            }
            return weapons;
        }

        public event EventHandler<PresentationModel.PriceChangeEventArgs> PriceChanged;
    }
}