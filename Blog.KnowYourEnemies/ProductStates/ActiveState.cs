using System;
using System.Reflection.Metadata.Ecma335;

namespace Blog.KnowYourEnemies.ProductStates
{
    public class ActiveState : IProductState
    {
        
        private Action OnNotSoldOutAction { get; }


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

        public IProductState SoldoutHandler(int quantity)
        {
            if (quantity > 0) return this; 
            return new SoldoutState(OnNotSoldOutAction);
        }

        public bool IsAvailable() => true;
    }
}