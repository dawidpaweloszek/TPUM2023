using Data;
using PresentationModel.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class WeaponPresentation : INotifyPropertyChanged
    {
        public WeaponPresentation(string name, float price, Guid id, CountryOfOrigin origin, WeaponType weaponType)
        {
            Name = name;
            Price = price;
            Id = id;
            Origin = origin;
            Type = weaponType;
        }

        public string Name { get; set; }
        public float Price { get; set; }
        public Guid Id { get; set; }
        public CountryOfOrigin Origin { get; set; }
        public WeaponType Type{ get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}