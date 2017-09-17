using System.Collections.Generic;
using System.Linq;

namespace Blog.KnowYourEnemies
{
    public class Cart
    {
        public IEnumerable<Product> Products { get; }


        public  Cart(IEnumerable<Product> porducts)
        {
            Products = porducts;
        }
        
        public Cart GetAvailable() => new Cart(Products.Where(prd=> prd.IsAvailable()));

        public decimal GetTotal() => GetAvailable().Products.Sum(prod => prod.Price);

    }
}