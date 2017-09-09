using System;
using System.Xml.Xsl;
using Blog.KnowYourEnemies.ProductStates;

namespace Blog.KnowYourEnemies
{
    public class Product
    {
        public int Quantity { get; private set; }

        public IProductState State { get; set; }


        public Product(int quantity,  IProductState productState)
        {
            Quantity = quantity;
            State = productState;
        }

        public void Deposit(int amount)
        {
            State = State.Deposit(() => Quantity += amount );

        }

        public void Withdraw(int amount)
        {
            if ( Quantity < amount) return;
            
            State = State.Withdraw(() => Quantity -= amount );
            State = State.IsSoldout(Quantity);
        }
    }
}