using Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;

namespace PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract int Radius { get; }
        public abstract string ColorString { get; }
        public abstract string MainViewVisibility { get; }
        public abstract string ShoppingCartViewVisibility { get; }
        public abstract WarehousePresentation WarehousePresentation { get; }
        public abstract ShoppingCart ShoppingCart { get; }

        public static ModelAbstractApi CreateApi(ILogicLayer logicLayer = default(ILogicLayer))
        {
            return new ModelApi(logicLayer ?? ILogicLayer.Create());
        }
    }

    internal class ModelApi : ModelAbstractApi
    {
        public ModelApi(ILogicLayer logicLayer)
        {
            this.logicLayer = logicLayer;
        }

        public override int Radius => 100;
        public override string ColorString => "Black";

        public override string MainViewVisibility => "Visiblie";

        public override string ShoppingCartViewVisibility => "Hidden";

        public override ShoppingCart ShoppingCart => new ShoppingCart(new ObservableCollection<WeaponPresentation>(), logicLayer.Shop);

        public override WarehousePresentation WarehousePresentation => new WarehousePresentation(logicLayer.Shop);

        private ILogicLayer logicLayer;
    }
}