using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PresentationModel
{
    public interface IWarehousePresentation
    {
        public Task SendMessageAsync(string message);
        public List<WeaponPresentation> GetWeapons();
        public Task<bool> Connect(Uri uri);
        public Task Disconnect();
        public bool IsConnected();

        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler<WeaponPresentation> WeaponChanged;
        public event EventHandler<WeaponPresentation> WeaponRemoved;
        public event EventHandler<List<WeaponPresentation>> TransactionSucceeded;
        public event EventHandler TransactionFailed;
    }
}
