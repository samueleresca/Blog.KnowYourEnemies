using System;

namespace Blog.KnowYourEnemies.ProductStates
{
    public class ActiveState : IProductState
    {
        
        private Action OnNotSoldOutAction { get; set; }


        public ActiveState(Action onNotSoldOutCondition)
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

        public IProductState IsSoldout(int quantity)
        {
            if (quantity > 0) return this; 
            return new SoldoutState(OnNotSoldOutAction);
        }
    }
}