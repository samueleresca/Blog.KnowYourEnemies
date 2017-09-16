using System;

namespace Blog.KnowYourEnemies.ProductStates
{
    public interface IProductState
    {
        IProductState Deposit(Action depositAction);
        IProductState Withdraw(Action withDrawAction);
        IProductState SoldoutHandler(int quantity);
        bool IsAvailable();

    }
}