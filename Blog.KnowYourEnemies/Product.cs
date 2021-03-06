﻿using Blog.KnowYourEnemies.ProductStates;

namespace Blog.KnowYourEnemies
{
    public class Product 
    {
        public int Quantity { get; private set; }
        public IProductState State { get; set; }
        public decimal Price { get; set; }


        public Product(int quantity,  IProductState productState)
        {
            Quantity = quantity;
            State = productState;
        }
        
        public Product(int quantity,  IProductState productState, decimal price)
        {
            Quantity = quantity;
            State = productState;
            Price = price;
        }

        public void Deposit(int amount) =>  State = State.Deposit(() => Quantity += amount );

        public bool IsAvailable() => State.IsAvailable();
        
        public void Withdraw(int amount)
        {
            if ( Quantity < amount) return;
            
            State = State.Withdraw(() => Quantity -= amount );
            State = State.SoldoutHandler(Quantity);
        }

    }

}