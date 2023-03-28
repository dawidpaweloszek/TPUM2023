using Data;
using Logic;
using System.Collections.Generic;

namespace LogicTest
{
    [TestClass]
    public class ShopTest
    {
        private IDataLayer dataLayer;
        private IShop shop;

        [TestInitialize]
        public void InitTest()
        {
            WarehouseTest warehouse = new WarehouseTest();


            List<IWeapon> weapons = new List<IWeapon>()
            {
                new Weapon("test0", 00.1f, CountryOfOrigin.England, WeaponType.Katana),
                new Weapon("test1", 10.2f, CountryOfOrigin.China, WeaponType.BattleAxe),
                new Weapon("test2", 20.3f, CountryOfOrigin.Korea, WeaponType.WarHammer),
                new Weapon("test3", 30.4f, CountryOfOrigin.Japan, WeaponType.TwoHandedSword),
                new Weapon("test4", 40.5f, CountryOfOrigin.Germany, WeaponType.BattleAxe)
            };

            warehouse.AddWeapons(weapons);

            dataLayer = new DataLayerTest(warehouse);
            Assert.IsNotNull(dataLayer);

            shop = new LogicLayer(dataLayer).Shop;
            Assert.IsNotNull(shop);
        }

        [TestMethod]
        public void SellTest()
        {
            List<WeaponDTO> weapons = shop.GetWeapons();
            Assert.IsNotNull(weapons);
            Assert.AreEqual(5, weapons.Count);

            List<WeaponDTO> battleAxes = weapons.FindAll(weapon => weapon.Type == WeaponType.BattleAxe.ToString());
            Assert.IsNotNull(battleAxes);
            
            battleAxes.ForEach(weapon => weapons.Remove(weapon));
            Assert.AreEqual(3, weapons.Count);
            Assert.AreEqual(2, battleAxes.Count);

            shop.Sell(battleAxes);

            List<WeaponDTO> weaponsLeftInShop = shop.GetWeapons();
            Assert.IsNotNull(weaponsLeftInShop);
            Assert.AreEqual(3, weaponsLeftInShop.Count);

            List<WeaponDTO> battleAxesLeftInShop = weaponsLeftInShop.FindAll(weapon => weapon.Type == WeaponType.BattleAxe.ToString());
            Assert.IsNotNull(battleAxesLeftInShop);
            Assert.AreEqual(0, battleAxesLeftInShop.Count);
        }

        [TestMethod]
        public void GetWeaponsTest()
        {
            List<WeaponDTO> weapons = shop.GetWeapons();
            Assert.IsNotNull(weapons);
            Assert.AreEqual(5, weapons.Count);
        }
    }
}