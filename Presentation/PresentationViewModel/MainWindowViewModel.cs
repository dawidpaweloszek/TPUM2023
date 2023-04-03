﻿using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using PresentationModel;
using PresentationViewModel.MVVMLight;
using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm;
using GalaSoft.MvvmLight.Command;
using System.Timers;
using Logic;
using Data;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {
        #region public API

        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            ModelLayer = modelAbstractApi;
            Radious = ModelLayer.Radius;
            ColorString = ModelLayer.ColorString;
            MainViewVisibility = ModelLayer.MainViewVisibility;
            ShoppingCartViewVisibility = ModelLayer.ShoppingCartViewVisibility;
            weapons = new ObservableCollection<WeaponPresentation>();
            foreach (WeaponPresentation weapon in ModelLayer.WarehousePresentation.GetWeapons())
            {
                Weapons.Add(weapon);
            }
            ModelLayer.WarehousePresentation.PriceChanged += OnPriceChanged;
            shoppingCart = ModelLayer.ShoppingCart;
            ButtomClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ClickHandler());
            ShoppingCartButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ShoppingCartButtonClickHandler());
            MainPageButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => MainPagetButtonClickHandler());
            AxesButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => AxesButtonClickHandler());
            HammersButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => HammersButtonClickHandler());
            KatanasButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => KatanasButtonClickHandler());
            SwordsButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => SwordsButtonClickHandler());

            BuyButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BuyButtonClickHandler());

            WeaponButtonClick = new RelayCommand<Guid>((id) => WeaponButtonClickHandler(id));

            ConnectButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ConnectButtonClickHandler());
            ConnectionService = ServiceFactory.CreateConnectionService;
        }

        private void OnPriceChanged(object sender, PresentationModel.PriceChangeEventArgs e)
        {
            ObservableCollection<WeaponPresentation> newWeapons = Weapons;
            WeaponPresentation weapon = newWeapons.FirstOrDefault(x => x.Id == e.Id);
            int weaponIndex = newWeapons.IndexOf(weapon);
            newWeapons[weaponIndex].Price = e.Price;
            Weapons = new ObservableCollection<WeaponPresentation>(newWeapons);
        }

        public string ColorString
        {
            get
            {
                return b_colorString;
            }
            set
            {
                if (value.Equals(b_colorString))
                    return;
                b_colorString = value;
                RaisePropertyChanged("ColorString");
            }
        }

        public string ConnectButtonText
        {
            get
            {
                return b_connectButtonText;
            }
            set
            {
                if (value.Equals(b_connectButtonText))
                    return;
                b_connectButtonText = value;
                RaisePropertyChanged("ConnectButtonText");
            }
        }

        public string MainViewVisibility
        {
            get
            {
                return b_mainViewVisibility;
            }
            set
            {
                if (value.Equals(b_mainViewVisibility))
                    return;
                b_mainViewVisibility = value;
                RaisePropertyChanged("MainViewVisibility");
            }
        }

        public string ShoppingCartViewVisibility
        {
            get
            {
                return b_shoppingCartViewVisibility;
            }
            set
            {
                if (value.Equals(b_shoppingCartViewVisibility))
                    return;
                b_shoppingCartViewVisibility = value;
                RaisePropertyChanged("ShoppingCartViewVisibility");
            }
        }

        public float ShoppingCartSum
        {
            get
            {
                return shoppingCartSum;
            }
            set
            {
                if (value.Equals(shoppingCartSum))
                    return;
                shoppingCartSum = value;
                RaisePropertyChanged("ShoppingCartSum");
            }
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                return shoppingCart;
            }
            set
            {
                if (value.Equals(shoppingCart))
                    return;
                shoppingCart = value;
                RaisePropertyChanged("ShoppingCart");
            }
        }
        public IList<object> CirclesCollection
        {
            get
            {
                return b_CirclesCollection;
            }
            set
            {
                if (value.Equals(b_CirclesCollection))
                    return;
                RaisePropertyChanged("CirclesCollection");
            }
        }

        public ObservableCollection<WeaponPresentation> Weapons
        {
            get
            {
                return weapons;
            }
            set
            {
                if (value.Equals(weapons))
                    return;
                weapons = value;
                RaisePropertyChanged("Weapons");
            }
        }

        public int Radious
        {
            get
            {
                return b_Radious;
            }
            set
            {
                if (value.Equals(b_Radious))
                    return;
                b_Radious = value;
                RaisePropertyChanged("Radious");
            }
        }

        public ICommand ButtomClick { get; set; }
        public ICommand ShoppingCartButtonClick { get; set; }
        public ICommand MainPageButtonClick { get; set; }
        public ICommand AxesButtonClick { get; set; }
        public ICommand HammersButtonClick { get; set; }
        public ICommand KatanasButtonClick { get; set; }
        public ICommand SwordsButtonClick { get; set; }
        public ICommand WeaponButtonClick { get; set; }
        public ICommand BuyButtonClick { get; set; }
        public ICommand ConnectButtonClick { get; set; }

        private void ClickHandler()
        {
            // do something usefull
            Radious *= 2;
            ColorString = "Magenta";
        }

        private async Task ConnectButtonClickHandler()
        {
            ConnectButtonText = "łączenie";
            bool result = await ConnectionService.Connect(new Uri("ws://localhost:8081"));
            if (result)
            {
                ConnectButtonText = "połączono";
            }
        }

        private void BuyButtonClickHandler()
        {
            ShoppingCart.Buy();
            ShoppingCartSum = ShoppingCart.Sum();
            Weapons.Clear();
            foreach (WeaponPresentation weapon in ModelLayer.WarehousePresentation.GetWeapons())
            {
                Weapons.Add(weapon);
            }
        }
        private void ShoppingCartButtonClickHandler()
        {
            ShoppingCartViewVisibility = "Visible";
            MainViewVisibility = "Hidden";
        }

        private void WeaponButtonClickHandler(Guid id)
        {
            foreach (WeaponPresentation weapon in ModelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Id.Equals(id))
                {
                    ShoppingCart.Add(weapon);
                    ShoppingCartSum = ShoppingCart.Sum();
                }  
            }
        }

        private void AxesButtonClickHandler()
        {
            Weapons.Clear();
            foreach (WeaponPresentation weapon in ModelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Type.Equals("BattleAxe"))
                    Weapons.Add(weapon);
            }
        }

        private void HammersButtonClickHandler()
        {
            Weapons.Clear();
            foreach (WeaponPresentation weapon in ModelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Type.Equals("WarHammer"))
                    Weapons.Add(weapon);
            }
        }

        private void KatanasButtonClickHandler()
        {
            Weapons.Clear();
            foreach (WeaponPresentation weapon in ModelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Type.Equals("Katana"))
                    Weapons.Add(weapon);
            }
        }

        private void SwordsButtonClickHandler()
        {
            Weapons.Clear();
            foreach (WeaponPresentation weapon in ModelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Type.Equals("TwoHandedSword"))
                    Weapons.Add(weapon);
            }
        }

        private void MainPagetButtonClickHandler()
        {
            ShoppingCartViewVisibility = "Hidden";
            MainViewVisibility = "Visible";
        }

        #endregion public API

        #region private

        private IList<object> b_CirclesCollection;
        private ShoppingCart shoppingCart;
        private float shoppingCartSum;
        private ObservableCollection<WeaponPresentation> weapons;
        private Timer timer;
        private int b_Radious;
        private string b_colorString;
        private string b_mainViewVisibility;
        private string b_shoppingCartViewVisibility;
        private ModelAbstractApi ModelLayer;
        private IConnectionService ConnectionService;
        private string b_connectButtonText;

        #endregion private

    }
}