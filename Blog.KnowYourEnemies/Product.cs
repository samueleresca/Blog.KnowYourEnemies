namespace Blog.KnowYourEnemies
{
       public class Product
       {
           public int Quantity { get; private set; }
           
           private bool IsBanned { get; set; }
   
   
           public Product( int quantity, bool isBanned= false)
           {
               Quantity = quantity;
               IsBanned = isBanned;
           }
           
           public void Deposit(int amount)
           {
               if (!IsBanned)
               {
                   Quantity += amount;
               }
           }
   
           public void Withdraw(int amount)
           {
               if (!IsBanned && Quantity >= amount)
               {
                   Quantity -= amount;
               }
           }
       }
}