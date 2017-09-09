using System;

namespace Blog.KnowYourEnemies.ProductStates
{
    public interface IProductState
    {
        IProductState Deposit(Action depositAction);
        IProductState Withdraw(Action withDrawAction);
        IProductState IsSoldout(int quantity);
    }
}