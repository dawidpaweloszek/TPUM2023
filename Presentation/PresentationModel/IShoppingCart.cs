using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PresentationModel
{
    public interface IShoppingCart
    {
        public ObservableCollection<WeaponPresentation> Weapons { get; set; }
        public void Add(WeaponPresentation weapon);
        public float Sum();
        public Task Buy();
    }
}
