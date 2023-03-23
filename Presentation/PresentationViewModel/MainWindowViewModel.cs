using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using PresentationModel;
using PresentationViewModel.MVVMLight;
using System.Collections.ObjectModel;
using Logic;
using Microsoft.Toolkit.Mvvm;
using GalaSoft.MvvmLight.Command;

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
            BasketViewVisibility = ModelLayer.BasketViewVisibility;
            weapons = new ObservableCollection<WeaponDTO>();
            foreach (WeaponDTO weapon in ModelLayer.WarehousePresentation.Shop.GetWeapons())
            {
                weapons.Add(weapon);
            }
            ButtomClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ClickHandler());
            BasketButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BasketButtonClickHandler());
            MainPageButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => MainPagetButtonClickHandler());
            AxesButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => AxesButtonClickHandler());
            HammersButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => HammersButtonClickHandler());
            KatanasButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => KatanasButtonClickHandler());
            SwordsButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => SwordsButtonClickHandler());

            WeaponButtonClick = new RelayCommand<Guid>((id) => WeaponButtonClickHandler(id));

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

        public string BasketViewVisibility
        {
            get
            {
                return b_basketViewVisibility;
            }
            set
            {
                if (value.Equals(b_basketViewVisibility))
                    return;
                b_basketViewVisibility = value;
                RaisePropertyChanged("BasketViewVisibility");
            }
        }
        public Basket Basket
        {
            get
            {
                return basket;
            }
            set
            {
                if (value.Equals(basket))
                    return;
                basket = value;
                RaisePropertyChanged("Basket");
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

        public ObservableCollection<WeaponDTO> Weapons
        {
            get
            {
                return weapons;
            }
            set
            {
                if (value.Equals(weapons))
                    return;
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
        public ICommand BasketButtonClick { get; set; }
        public ICommand MainPageButtonClick { get; set; }
        public ICommand AxesButtonClick { get; set; }
        public ICommand HammersButtonClick { get; set; }
        public ICommand KatanasButtonClick { get; set; }
        public ICommand SwordsButtonClick { get; set; }

        public ICommand WeaponButtonClick { get; set; }

        private void ClickHandler()
        {
            // do something usefull
            Radious *= 2;
            ColorString = "Magenta";
            //this.Navigate(new Uri("BasketWindow.xaml", UriKind.Relative));
        }

        private void BasketButtonClickHandler()
        {
            BasketViewVisibility = "Visible";
            MainViewVisibility = "Hidden";
        }

        private void WeaponButtonClickHandler(Guid id)
        {
            foreach (WeaponDTO weapon in ModelLayer.WarehousePresentation.Shop.GetWeapons())
            {
                if (weapon.Id.Equals(id))
                    Basket.Add(weapon);
            }
        }

        private void AxesButtonClickHandler()
        {
            weapons.Clear();
            foreach (WeaponDTO weapon in ModelLayer.WarehousePresentation.Shop.GetWeapons())
            {
                if (weapon.Type.ToLower().Equals("BattleAxe"))
                    weapons.Add(weapon);
            }
        }

        private void HammersButtonClickHandler()
        {
            weapons.Clear();
            foreach (WeaponDTO weapon in ModelLayer.WarehousePresentation.Shop.GetWeapons())
            {
                if (weapon.Type.ToLower().Equals("WarHammer"))
                    weapons.Add(weapon);
            }
        }

        private void KatanasButtonClickHandler()
        {
            weapons.Clear();
            foreach (WeaponDTO weapon in ModelLayer.WarehousePresentation.Shop.GetWeapons())
            {
                if (weapon.Type.ToLower().Equals("Katana"))
                    weapons.Add(weapon);
            }
        }

        private void SwordsButtonClickHandler()
        {
            weapons.Clear();
            foreach (WeaponDTO weapon in ModelLayer.WarehousePresentation.Shop.GetWeapons())
            {
                if (weapon.Type.ToLower().Equals("TwoHandedSword"))
                    weapons.Add(weapon);
            }
        }

        private void MainPagetButtonClickHandler()
        {
            BasketViewVisibility = "Hidden";
            MainViewVisibility = "Visible";
        }

        #endregion public API

        #region private

        private IList<object> b_CirclesCollection;
        private Basket basket;
        private ObservableCollection<WeaponDTO> weapons;
        private int b_Radious;
        private string b_colorString;
        private string b_mainViewVisibility;
        private string b_basketViewVisibility;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();

        #endregion private

    }
}