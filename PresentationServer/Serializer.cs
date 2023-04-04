using DataServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LogicServer;

namespace PresentationServer
{
    public abstract class Serializer
    {
        public static string WeaponToJSON(IWeaponDTO weapon)
        {
            return JsonSerializer.Serialize(weapon);
        }

        public static IWeaponDTO JSONToWeapon(string json)
        {
            return JsonSerializer.Deserialize<WeaponDTO>(json);
        }

        public static string WarehouseToJSON(List<IWeaponDTO> weapons)
        {
            return JsonSerializer.Serialize(weapons);
        }

        public static List<IWeaponDTO> JSONToWarehouse(string json)
        {
            return new List<IWeaponDTO>(JsonSerializer.Deserialize<List<WeaponDTO>>(json));
        }
    }
}
