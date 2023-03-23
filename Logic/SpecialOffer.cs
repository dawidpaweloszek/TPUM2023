using Data;
using System;
using System.Timers;

namespace Logic
{
    internal class SpecialOffer : ISpecialOffer
    {
        private Guid WeaponOnSaleId { get; set; }
        private Timer SaleTimer { get; }
        private float Sale { get; set; }
        private IWarehouse Warehouse { get; set; }
        private Random Rand { get; set; }

        public SpecialOffer(IWarehouse warehouse)
        {
            SaleTimer = new System.Timers.Timer(2137);
            SaleTimer.Elapsed += GetNewSale;
            SaleTimer.AutoReset = true;
            SaleTimer.Enabled = true;
            Warehouse = warehouse;
            Rand = new Random();
        }

        public Tuple<Guid, float> GetSpecialOffer()
        {
            return new Tuple<Guid, float>(WeaponOnSaleId, Sale);
        }

        private void GetNewSale(Object source, ElapsedEventArgs e)
        {
            Sale = ((float)Rand.NextDouble() / 4.0f) + 0.75f;
            WeaponOnSaleId = Warehouse.Stock[Rand.Next(0, Warehouse.Stock.Count)].Id;
        }
    }
}
