using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Blog.KnowYourEnemies
{
    public class Cart
    {
        public IEnumerable<Product> Products { get; }


        public  Cart(IEnumerable<Product> porducts)
        {
            Products = porducts;
        }
        
        public Cart GetAvailable() => new Cart(Products.Where(prd=> prd.State.IsAvailable()));

        public decimal GetTotal() => GetAvailable().Products.Sum(prod => prod.Price);

    }
}