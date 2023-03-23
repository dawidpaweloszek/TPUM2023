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
            dataLayer = new DataLayerTest();
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