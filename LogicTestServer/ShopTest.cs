using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataServer;
using LogicServer;

namespace LogicTestServer
{
    [TestClass]
    public class ShopTest
    {
        private IDataLayer dataLayer;
        private IShop shop;

        [TestInitialize]
        public void Initialize()
        {
            //dataLayer = IDataLayer.Create();
            WarehouseTest warehouse = new WarehouseTest();

            List<IWeapon> weapons = new List<IWeapon>();
            weapons.Add(new Weapon("Katana szybciutka", 629f, CountryOfOrigin.Poland, WeaponType.Katana));
            weapons.Add(new Weapon("Miecz szybki", 169f, CountryOfOrigin.England, WeaponType.TwoHandedSword));
            weapons.Add(new Weapon("Topór mocarny", 269f, CountryOfOrigin.Japan, WeaponType.BattleAxe));
            weapons.Add(new Weapon("Młot ciężkawy", 2269f, CountryOfOrigin.Germany, WeaponType.WarHammer));
            weapons.Add(new Weapon("Katana szybciutka 2", 1629f, CountryOfOrigin.Poland, WeaponType.Katana));
            weapons.Add(new Weapon("Miecz szybki 2", 162f, CountryOfOrigin.England, WeaponType.TwoHandedSword));
            weapons.Add(new Weapon("Topór mocarny 2", 169f, CountryOfOrigin.Japan, WeaponType.BattleAxe));
            weapons.Add(new Weapon("Młot ciężkawy 2", 1269f, CountryOfOrigin.Germany, WeaponType.WarHammer));
            warehouse.AddWeapons(weapons);

            dataLayer = new DataLayerTest (warehouse);
            Assert.IsNotNull(dataLayer);


            shop = ILogicLayer.Create(dataLayer).Shop;

        }

        [TestMethod]
        public void GetAvailableProducts()
        {
            List<IWeaponDTO> weapons = shop.GetWeapons();
            Assert.IsNotNull(weapons);
            Assert.AreEqual(8, weapons.Count);
        }

        [TestMethod]
        public void SellAllTest()
        {
            List<IWeaponDTO> weapons = shop.GetWeapons();
            Assert.IsNotNull(weapons);
            Assert.AreEqual(8, weapons.Count);

            shop.Sell(weapons);

            List<IWeaponDTO> remainingWeapons = shop.GetWeapons();
            Assert.IsNotNull(remainingWeapons);
            Assert.AreEqual(0, remainingWeapons.Count);
        }

        [TestMethod]
        public void SellTest()
        {
            List<IWeaponDTO> weapons = shop.GetWeapons();
            Assert.IsNotNull(weapons);
            Assert.AreEqual(8, weapons.Count);

            List<IWeaponDTO> weaponsFromPoland = weapons.FindAll(x => x.Origin.Equals(5));
            weaponsFromPoland.ForEach(x => weapons.Remove(x));
            Assert.AreEqual(6, weapons.Count);
            Assert.AreEqual(2, weaponsFromPoland.Count);

            shop.Sell(weaponsFromPoland);

            List<IWeaponDTO> remainingWeapons = shop.GetWeapons();
            Assert.IsNotNull(remainingWeapons);
            Assert.AreEqual(6, remainingWeapons.Count);

            List<IWeaponDTO> weaponsInShopFromPoland = remainingWeapons.FindAll(x => x.Origin.Equals(5));
            Assert.IsNotNull(weaponsInShopFromPoland);
            Assert.AreEqual(0, weaponsInShopFromPoland.Count);
        }
    }
}