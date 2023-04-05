using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using PresentationModel;
using PresentationViewModel.MVVMLight;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Logic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationViewModel
{
    public class MainWindowViewModel : ViewModelBase

    {
        #region public API

        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi()) { }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
            modelLayer = modelAbstractApi;
            MainViewVisibility = modelLayer.MainViewVisibility;
            ShoppingCartViewVisibility = modelLayer.ShoppingCartViewVisibility;
            weapons = new ObservableCollection<WeaponPresentation>();
            foreach (WeaponPresentation weapon in modelLayer.WarehousePresentation.GetWeapons())
            {
                Weapons.Add(weapon);
            }
            modelLayer.WarehousePresentation.PriceChanged += OnPriceChanged;
            modelLayer.WarehousePresentation.WeaponChanged += OnWeaponChanged;
            modelLayer.WarehousePresentation.WeaponRemoved += OnWeaponRemoved;

            modelLayer.WarehousePresentation.TransactionFailed += OnTransactionFailed;
            modelLayer.WarehousePresentation.TransactionSucceeded += OnTransactionSucceeded;
            shoppingCart = modelLayer.ShoppingCart;
            ShoppingCartButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ShoppingCartButtonClickHandler());
            MainPageButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => MainPageButtonClickHandler());
            AxesButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => AxesButtonClickHandler());
            HammersButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => HammersButtonClickHandler());
            KatanasButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => KatanasButtonClickHandler());
            SwordsButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => SwordsButtonClickHandler());

            BuyButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => BuyButtonClickHandler());

            WeaponButtonClick = new RelayCommand<Guid>((id) => WeaponButtonClickHandler(id));

            ConnectButtonClick = new GalaSoft.MvvmLight.Command.RelayCommand(() => ConnectButtonClickHandler());
            connectionService = ServiceFactory.CreateConnectionService;
            connectionService.ConnectionLogger += s => Log = s;
        }

        private void OnWeaponRemoved(object? sender, WeaponPresentation e)
        {
            ObservableCollection<WeaponPresentation> newWeapons = new ObservableCollection<WeaponPresentation>(Weapons);
            WeaponPresentation Weapon = newWeapons.FirstOrDefault(x => x.Id == e.Id);

            if (Weapon != null)
            {
                int weaponIndex = newWeapons.IndexOf(Weapon);
                newWeapons.RemoveAt(weaponIndex);
            }

            Weapons = new ObservableCollection<WeaponPresentation>(newWeapons);
        }

        public string Log
        {
            get => log;
            set
            {
                log = value;
                RaisePropertyChanged("Log");
            }
        }

        private void OnTransactionSucceeded(object? sender, List<WeaponPresentation> e)
        {
            TransactionStatusText = "Bron zakupiona";
        }

        private void OnTransactionFailed(object? sender, EventArgs e)
        {
            TransactionStatusText = "Bron nie zostala kupiona";
        }

        private void OnWeaponChanged(object? sender, WeaponPresentation e)
        {
            ObservableCollection<WeaponPresentation> newWeapons = new ObservableCollection<WeaponPresentation>(Weapons);
            WeaponPresentation weapon = newWeapons.FirstOrDefault(x => x.Id == e.Id);

            if (weapon != null)
            {
                int weaponIndex = newWeapons.IndexOf(weapon);
                
                if (e.Type.ToLower() == "deleted")
                    newWeapons.RemoveAt(weaponIndex);
                else
                {
                    newWeapons[weaponIndex].Name = e.Name;
                    newWeapons[weaponIndex].Price = e.Price;
                    newWeapons[weaponIndex].Id = e.Id;
                    newWeapons[weaponIndex].Type = e.Type;
                }
            }
            else
                newWeapons.Add(e);
            
            Weapons = new ObservableCollection<WeaponPresentation>(newWeapons);
        }

        private void OnPriceChanged(object sender, PresentationModel.PriceChangeEventArgs e)
        {
            ObservableCollection<WeaponPresentation> newWeapons = Weapons;
            WeaponPresentation weapon = newWeapons.FirstOrDefault(x => x.Id == e.Id);
            int weaponIndex = newWeapons.IndexOf(weapon);
            newWeapons[weaponIndex].Price = e.Price;
            Weapons = new ObservableCollection<WeaponPresentation>(newWeapons);
        }

        public string ConnectButtonText
        {
            get { return connectButtonText; }
            set
            {
                if (value.Equals(connectButtonText))
                    return;
                connectButtonText = value;
                RaisePropertyChanged("ConnectButtonText");
            }
        }

        public string MainViewVisibility
        {
            get { return mainViewVisibility; }
            set
            {
                if (value.Equals(mainViewVisibility))
                    return;
                mainViewVisibility = value;
                RaisePropertyChanged("MainViewVisibility");
            }
        }

        public string ShoppingCartViewVisibility
        {
            get { return shoppingCartViewVisibility; }
            set
            {
                if (value.Equals(shoppingCartViewVisibility))
                    return;
                shoppingCartViewVisibility = value;
                RaisePropertyChanged("ShoppingCartViewVisibility");
            }
        }

        public float ShoppingCartSum
        {
            get { return shoppingCartSum; }
            set
            {
                if (value.Equals(shoppingCartSum))
                    return;
                shoppingCartSum = value;
                RaisePropertyChanged("ShoppingCartSum");
            }
        }

        public string TransactionStatusText
        {
            get { return transactionStatusText; }
            set 
            {
                if (value.Equals(transactionStatusText))
                    return;
                transactionStatusText = value;
                RaisePropertyChanged("Transaction Status Text");
            }
        }

        public IShoppingCart ShoppingCart
        {
            get { return shoppingCart; }
            set
            {
                if (value.Equals(shoppingCart))
                    return;
                shoppingCart = value;
                RaisePropertyChanged("ShoppingCart");
            }
        }

        public ObservableCollection<WeaponPresentation> Weapons
        {
            get { return weapons; }
            set
            {
                if (value.Equals(weapons))
                    return;
                weapons = value;
                RaisePropertyChanged("Weapons");
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

        private async Task ConnectButtonClickHandler()
        {
            if (!connectionService.Connected)
            {
                ConnectButtonText = "łączenie";
                bool result = await connectionService.Connect(new Uri("ws://localhost:8081"));

                if (result)
                {
                    ConnectButtonText = "połączono";
                    Weapons.Clear();
                    foreach (WeaponPresentation weapon in modelLayer.WarehousePresentation.GetWeapons())
                        Weapons.Add(weapon);
                }
            }
            else
            {
                await connectionService.Disconnect();
                ConnectButtonText = "rozłączono";
                Weapons.Clear();
            }
        }

        private void BuyButtonClickHandler()
        {
            ShoppingCart.Buy();
            ShoppingCartSum = ShoppingCart.Sum();
            Weapons.Clear();
            foreach (WeaponPresentation weapon in modelLayer.WarehousePresentation.GetWeapons())
            {
                Weapons.Add(weapon);
            }
        }
        private void ShoppingCartButtonClickHandler()
        {
            ShoppingCartViewVisibility = "Visible";
            MainViewVisibility = "Hidden";

            modelLayer.WarehousePresentation.SendMessageAsync("Shopping cart button clicked");
        }

        private void WeaponButtonClickHandler(Guid id)
        {
            foreach (WeaponPresentation weapon in modelLayer.WarehousePresentation.GetWeapons())
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
            foreach (WeaponPresentation weapon in modelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Type.Equals("BattleAxe"))
                    Weapons.Add(weapon);
            }
        }

        private void HammersButtonClickHandler()
        {
            Weapons.Clear();
            foreach (WeaponPresentation weapon in modelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Type.Equals("WarHammer"))
                    Weapons.Add(weapon);
            }
        }

        private void KatanasButtonClickHandler()
        {
            Weapons.Clear();
            foreach (WeaponPresentation weapon in modelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Type.Equals("Katana"))
                    Weapons.Add(weapon);
            }
        }

        private void SwordsButtonClickHandler()
        {
            Weapons.Clear();
            foreach (WeaponPresentation weapon in modelLayer.WarehousePresentation.GetWeapons())
            {
                if (weapon.Type.Equals("TwoHandedSword"))
                    Weapons.Add(weapon);
            }
        }

        private void MainPageButtonClickHandler()
        {
            ShoppingCartViewVisibility = "Hidden";
            MainViewVisibility = "Visible";

            TransactionStatusText = "";

            modelLayer.WarehousePresentation.SendMessageAsync("main page button click");
        }

        #endregion public API

        #region private

        private IShoppingCart shoppingCart;
        private float shoppingCartSum;
        private ObservableCollection<WeaponPresentation> weapons;
        private string mainViewVisibility;
        private string shoppingCartViewVisibility;
        private ModelAbstractApi modelLayer;
        private IConnectionService connectionService;
        private string connectButtonText;
        private string transactionStatusText;
        private string log = "Waiting for connection logs...";

        #endregion private
    }
}