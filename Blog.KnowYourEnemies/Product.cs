using System;

namespace Blog.KnowYourEnemies
{
       public class Product
       {
           public int Quantity { get; private set; }
           
           public bool IsSoldout { get; private set; }

           private bool IsBanned { get; set; }

           private Action OnSoldOut { get; set; }


           public Product(int quantity, Action onSoldOut,  bool isBanned = false, bool isSoldout = true)
           {
               Quantity = quantity;
               IsBanned = isBanned;
               IsSoldout = isSoldout;
               OnSoldOut = onSoldOut;
           }
           
           public void Deposit(int amount)
           {
               if (IsBanned) return;
               Quantity += amount;

               if (IsSoldout)
               {
                   IsSoldout = false;
                   OnSoldOut();
               }
           }
   
           public void Withdraw(int amount)
           {
               if (!IsBanned && Quantity >= amount)
               {
                   Quantity -= amount;
                   
                   if (Quantity == 0)
                   {
                       IsSoldout = true;
                   }
               } 
           }
       }
}