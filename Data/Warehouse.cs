using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Warehouse
    {
        public List<Vegetable> Stock { get; set; }

        private Warehouse() 
        {
            Stock = new List<Vegetable>();
        }

        public static Warehouse CreateInstance() 
        { 
            return new Warehouse();
        }

        public void RemoveVeggies(List<Vegetable> vegs) 
        {
            vegs.ForEach(v => Stock.Remove(v));
        }
    }

    public interface IWarehouse
    {
        void RemoveVeggies(List<Vegetable> vegs);
    }
}
