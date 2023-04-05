using Logic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;

namespace PresentationModel
{
    public abstract class ModelAbstractApi
    {
        public abstract string MainViewVisibility { get; }
        public abstract string ShoppingCartViewVisibility { get; }
        public abstract IWarehousePresentation WarehousePresentation { get; }
        public abstract IShoppingCart ShoppingCart { get; }

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

        public override string MainViewVisibility => "Visiblie";

        public override string ShoppingCartViewVisibility => "Hidden";

        public override IShoppingCart ShoppingCart => new ShoppingCart(new ObservableCollection<WeaponPresentation>(), logicLayer.Shop);

        public override IWarehousePresentation WarehousePresentation => new WarehousePresentation(logicLayer.Shop);

        private ILogicLayer logicLayer;
    }
}