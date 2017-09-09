using System;

namespace Blog.KnowYourEnemies.ProductStates
{
    public class SoldoutState : IProductState
    {

        private Action OnNotSoldOutAction { get; set; }

        public SoldoutState(Action onNotSoldOutAction)
        {
            OnNotSoldOutAction = onNotSoldOutAction;
        }

        public IProductState Deposit(Action depositAction)
        {
            OnNotSoldOutAction();
            return new ActiveState(OnNotSoldOutAction);
        }

        public IProductState Withdraw(Action withDrawAction) => this;

        public IProductState IsSoldout(int quantity) => this;
    }
}