using System;

namespace Blog.KnowYourEnemies.ProductStates
{
    public class ProductState : IProductState
    {
        
        private Action OnNotSoldOutAction { get; set; }


        public ProductState(Action onNotSoldOutCondition)
        {
            OnNotSoldOutAction = onNotSoldOutCondition;
        }

        public IProductState Deposit(Action depositAction)
        {
            depositAction();
            return this;
        }

        public IProductState Withdraw(Action withDrawAction)
        {
            withDrawAction();
            return this;
        }

        public IProductState Soldout(int quantity)
        {
            if (quantity > 0) return this; 
            return new SoldoutState(OnNotSoldOutAction);
        }
    }
}