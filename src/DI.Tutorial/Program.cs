using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1 - Stage 1");
                Console.WriteLine("2 - Stage 2");
                Console.WriteLine("3 - Stage 3");
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.Write("Select demo initialization: ");
                string choice = Console.ReadLine();
                if (choice == "0")
                    exit = true;
                else
                {
                    OrderInfo orderInfo = new OrderInfo()
                    {
                        CustomerName = "Miguel Castro",
                        Email = "miguelcastro67@gmail.com",
                        Product = "Laptop",
                        Price = 1200,
                        CreditCard = "1234567890"
                    };

                    Console.WriteLine();
                    Console.WriteLine("Order Processing:");
                    Console.WriteLine();

                    switch (choice)
                    {
                        case "1":
                            #region stage 1
                            Stage1.Commerce commerce1 = new Stage1.Commerce();
                            commerce1.ProcessOrder(orderInfo);
                            #endregion

                            break;
                        case "2":
                            #region stage 2
                            Stage2.Commerce commerce2 = 
                                new Stage2.Commerce(
                                    new Stage2.BillingProcessor(), 
                                    new Stage2.CustomerProcessor(
                                        new Stage2.CustomerRepository(),
                                        new Stage2.ProductRepository()),
                                    new Stage2.Notifier());
                            commerce2.ProcessOrder(orderInfo);
                            #endregion

                            break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press 'Enter' for menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
