using System;

namespace Blog.KnowYourEnemies.ProductStates
{
    public class BannedState : IProductState
    {
        private Action OnNotSoldOutAction { get; set; }


        public BannedState(Action onNotSoldOutCondition)
        {
            OnNotSoldOutAction = onNotSoldOutCondition;
        }
        
        public IProductState  Deposit(Action depositAction) =>  this;
        public IProductState Withdraw(Action withDrawAction) => this;
        public IProductState IsSoldout(int quantity) => this;
    }
}