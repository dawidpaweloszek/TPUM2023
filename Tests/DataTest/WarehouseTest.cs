using Data;

namespace DataTest
{
    [TestClass]
    public class WarehouseTest
    {
        private IWarehouse warehouse;

        [TestInitialize]
        public void InitTest()
        {
            warehouse = IDataLayer.Create().Warehouse;
            Assert.IsNotNull(warehouse);

            warehouse.Stock.Clear();
            Assert.AreEqual(0, warehouse.Stock.Count);

            List<IWeapon> weapons = new List<IWeapon>
            {
                new Weapon("test0", 00.1f, CountryOfOrigin.England, WeaponType.Katana),
                new Weapon("test4", 40.5f, CountryOfOrigin.England, WeaponType.BattleAxe),
            };

            warehouse.AddWeapons(weapons);
        }

        [TestMethod]
        public void AddToStockTest()
        {
            List<IWeapon> weapons = new List<IWeapon>
            {
                new Weapon("test1", 10.2f, CountryOfOrigin.China, WeaponType.BattleAxe),
                new Weapon("test2", 20.3f, CountryOfOrigin.Korea, WeaponType.WarHammer),
                new Weapon("test3", 30.4f, CountryOfOrigin.Japan, WeaponType.TwoHandedSword)
            };

            warehouse.AddWeapons(weapons);
            Assert.AreEqual(5, warehouse.Stock.Count);
        }

        [TestMethod]
        public void GetWeaponsOfTypeTest()
        {
            List<IWeapon> weapons = warehouse.GetWeaponsOfType(WeaponType.Katana);
            Assert.IsNotNull(weapons);
            Assert.AreEqual(1, weapons.Count);
            Assert.AreEqual(WeaponType.Katana, weapons[0].Type);
        }

        [TestMethod]
        public void RemoveFromStockTest()
        {
            List<IWeapon> weapons = warehouse.GetWeaponsOfType(WeaponType.Katana);
            Assert.IsNotNull(weapons);

            warehouse.RemoveWeapons(weapons);
            Assert.AreEqual(1, warehouse.Stock.Count);
        }
    }
}