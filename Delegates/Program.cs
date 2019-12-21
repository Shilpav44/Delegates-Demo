using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace Delegates
{
    class Program
    {
        static ShoppingCartModel cart = new ShoppingCartModel();
        static void Main(string[] args)
        {
            PopulateCartWithDemoData();
            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser):C2}");
            Console.WriteLine("");
            decimal total = cart.GenerateTotal((subTotal) => Console.WriteLine($"The subTotalttttt for the cart2 id {subTotal:c2}"),
               (products,subTotal)=> {

                if(products.Count>3)
                   {
                       return subTotal * 0.5M;
                   }
                   else
                   {
                       return subTotal;
                   }

               },(discountMessage)=> { Console.WriteLine(discountMessage); });
            Console.WriteLine($"The total for the cart 2 is {total:c2}");
            Console.WriteLine();

            decimal total2=cart.GenerateTotal((subsubTotal) => Console.WriteLine($"the sub sub total is{subsubTotal:C2}"),
                       (products,subitotal)=> { return subitotal * 2M; },(message)=>Console.WriteLine(message));
            Console.WriteLine($"The total for the cart 3 is {total2:c2}");
            Console.WriteLine();

            Console.Write("Please press any key to exit the application...");
            Console.ReadLine();
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The Sub Total is {subTotal:c2}");
        }
        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        private static decimal CalculateLeveledDiscount(List<ProductModel> items,decimal subTotal)
        {
            if (subTotal > 100)
            {
                return subTotal * 0.8M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.9M;
            }
            else
            {
                return subTotal;
            }
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "BlueBerries", Price = 8.84M });
        }
    }
}
