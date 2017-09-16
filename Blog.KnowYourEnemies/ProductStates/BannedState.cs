using System;

namespace Blog.KnowYourEnemies.ProductStates
{
    public class BannedState : IProductState
    {
        private Action OnNotSoldOutAction { get; }


        public BannedState(Action onNotSoldOutCondition)
        {
            OnNotSoldOutAction = onNotSoldOutCondition;
        }
        
        public IProductState  Deposit(Action depositAction) =>  this;
        public IProductState Withdraw(Action withDrawAction) => this;
        public IProductState SoldoutHandler(int quantity) => this;

        public bool IsAvailable() => false;
    }
}