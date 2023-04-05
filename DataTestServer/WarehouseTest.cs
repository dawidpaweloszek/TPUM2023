using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataServer;

namespace DataTestServer
{
    [TestClass]
    public class WarehouseTest
    {
        private IWarehouse warehouse;
        [TestInitialize]
        public void Initialize()
        {
            warehouse = IDataLayer.Create().Warehouse;
            Assert.IsNotNull(warehouse);
            warehouse.Stock.Clear();
            Assert.AreEqual(0, warehouse.Stock.Count);

            List<IWeapon> weaponsToAdd = new List<IWeapon>();
            weaponsToAdd.Add(new Weapon("Miecz Absolutny", 230f, CountryOfOrigin.Poland, WeaponType.TwoHandedSword));
            weaponsToAdd.Add(new Weapon("M³ot okrutny", 2220f, CountryOfOrigin.China, WeaponType.WarHammer));
            weaponsToAdd.Add(new Weapon("Katana uwu", 1140f, CountryOfOrigin.Japan, WeaponType.Katana));
            weaponsToAdd.Add(new Weapon("Topór ostry", 510f, CountryOfOrigin.England, WeaponType.BattleAxe));

            warehouse.AddWeapons(weaponsToAdd);
        }

        [TestMethod]
        public void AddWeaponsTest()
        {
            List<IWeapon> weaponsToAdd = new List<IWeapon>();
            weaponsToAdd.Add(new Weapon("Miecz Absolutny dodany", 230f, CountryOfOrigin.Poland, WeaponType.TwoHandedSword));
            weaponsToAdd.Add(new Weapon("M³ot okrutny dodany", 2220f, CountryOfOrigin.China, WeaponType.WarHammer));
            weaponsToAdd.Add(new Weapon("Katana uwu dodany", 1140f, CountryOfOrigin.Japan, WeaponType.Katana));
            weaponsToAdd.Add(new Weapon("Topór ostry dodany", 510f, CountryOfOrigin.England, WeaponType.BattleAxe));

            warehouse.AddWeapons(weaponsToAdd);
            Assert.AreEqual(8, warehouse.Stock.Count);
        }
        [TestMethod]
        public void GetWeaponTest()
        {
            List<IWeapon> katanas = warehouse.GetWeaponsOfType(WeaponType.Katana);

            Assert.IsNotNull(katanas);
            Assert.AreEqual(1, katanas.Count);
        }
        [TestMethod]
        public void RemoveWeapons()
        {
            List<IWeapon> axes = warehouse.GetWeaponsOfType(WeaponType.BattleAxe);

            Assert.IsNotNull(axes);
            warehouse.RemoveWeapons(axes);
            Assert.AreEqual(3, warehouse.Stock.Count);
        }
    }
}