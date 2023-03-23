using System.Collections;
using System.Collections.Generic;
using Data;

namespace LogicTest
{
    internal class DataLayerTest : IDataLayer
    {
        public IWarehouse Warehouse { get; set; }

        public DataLayerTest()
        {
            Warehouse = new Warehouse();
            Warehouse.Stock.Clear();

            List<IWeapon> weapons = new List<IWeapon>()
            {
                new Weapon("test0", 00.1f, CountryOfOrigin.England, WeaponType.Katana),
                new Weapon("test1", 10.2f, CountryOfOrigin.China, WeaponType.BattleAxe),
                new Weapon("test2", 20.3f, CountryOfOrigin.Korea, WeaponType.WarHammer),
                new Weapon("test3", 30.4f, CountryOfOrigin.Japan, WeaponType.TwoHandedSword),
                new Weapon("test4", 40.5f, CountryOfOrigin.Germany, WeaponType.BattleAxe)
            };

            Warehouse.AddWeapons(weapons);
        }
    }
}
