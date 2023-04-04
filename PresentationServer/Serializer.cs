using DataServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PresentationServer
{
    public abstract class Serializer
    {
        public static string WeaponToJSON(IWeapon weapon)
        {
            return JsonSerializer.Serialize(weapon);
        }

        public static IWeapon JSONToWeapon(string json)
        {
            return JsonSerializer.Deserialize<Weapon>(json);
        }

        public static string WarehouseToJSON(List<IWeapon> weapons)
        {
            return JsonSerializer.Serialize(weapons);
        }

        public static List<IWeapon> JSONToWarehouse(string json)
        {
            return new List<IWeapon>(JsonSerializer.Deserialize<List<Weapon>>(json)!);
        }
    }
}
