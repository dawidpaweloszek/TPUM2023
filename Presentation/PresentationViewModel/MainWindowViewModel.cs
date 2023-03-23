using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using PresentationModel;
using PresentationViewModel.MVVMLight;
using System.Collections.ObjectModel;
using Logic;

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
            ButtomClick = new RelayCommand(() => ClickHandler());
            BasketButtonClick = new RelayCommand(() => BasketButtonClickHandler());
            MainPageButtonClick = new RelayCommand(() => MainPagetButtonClickHandler());

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

        private void MainPagetButtonClickHandler()
        {
            BasketViewVisibility = "Hidden";
            MainViewVisibility = "Visible";
        }

        #endregion public API

        #region private

        private IList<object> b_CirclesCollection;
        private ObservableCollection<WeaponDTO> weapons;
        private int b_Radious;
        private string b_colorString;
        private string b_mainViewVisibility;
        private string b_basketViewVisibility;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();

        #endregion private

    }
}