using Data;
using Logic;
using System.Collections.Generic;

namespace LogicTest
{
    [TestClass]
    public class ShopTest
    {
        private DataLayer dataLayer;
        private IShop shop;

        [TestInitialize]
        public void InitTest()
        {
            dataLayer = DataLayer.Create();
            Assert.IsNotNull(dataLayer);

            dataLayer.Warehouse.Stock.Clear();
            Assert.AreEqual(0, dataLayer.Warehouse.Stock.Count);

            List<IWeapon> weapons = new List<IWeapon>
            {
                new Weapon("test0", 00.1f, CountryOfOrigin.England, WeaponType.Katana),
                new Weapon("test1", 10.2f, CountryOfOrigin.China, WeaponType.BattleAxe),
                new Weapon("test2", 20.3f, CountryOfOrigin.Korea, WeaponType.WarHammer),
                new Weapon("test3", 30.4f, CountryOfOrigin.Japan, WeaponType.TwoHandedSword),
                new Weapon("test4", 40.5f, CountryOfOrigin.Germany, WeaponType.BattleAxe)
            };

            dataLayer.Warehouse.AddWeapons(weapons);
            Assert.AreEqual(5, dataLayer.Warehouse.Stock.Count);

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