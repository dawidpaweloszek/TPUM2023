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
        public WeaponPresentation(string name, float price, Guid id, string origin, string weaponType)
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
        public string Origin { get; set; }
        public string Type{ get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}