using System;
using System.Linq;

namespace DI.Tutorial.Stage1
{
    public class ProductRepository
    {
        public void Save()
        {
            Console.WriteLine("Product inventory updated.");
        }
    }
}
