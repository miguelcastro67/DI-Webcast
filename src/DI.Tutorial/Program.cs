using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace DI.Tutorial
{
    class Program
    {
        public static IContainer Container;

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
                Console.Write("Select demo: ");
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
                        case "3":
                            #region stage 3

                            ContainerBuilder builder = new ContainerBuilder();

                            builder.RegisterType<Stage3.Commerce>();
                            builder.RegisterType<Stage3.Notifier>().As<Stage3.INotifier>();
                            
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Processor") && t.Namespace.EndsWith("Stage3"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));
                            
                            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                                .Where(t => t.Name.EndsWith("Repository") && t.Namespace.EndsWith("Stage3"))
                                .As(t => t.GetInterfaces().FirstOrDefault(
                                    i => i.Name == "I" + t.Name));
                            
                            builder.RegisterType<Stage3.Logger>().As<Stage3.ILogger>();

                            Container = builder.Build();

                            Stage3.Commerce commerce3 = Container.Resolve<Stage3.Commerce>();

                            commerce3.ProcessOrder(orderInfo);
                            
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
