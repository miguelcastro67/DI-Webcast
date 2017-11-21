using System;
using System.Linq;

namespace DI.Tutorial.Stage1
{
    public class CustomerProcessor
    {
        public void UpdateCustomerOrder(string customer, string product)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            ProductRepository productRepository = new ProductRepository();

            customerRepository.Save();
            productRepository.Save();

            Console.WriteLine(string.Format("Customer record for '{0}' updated with purchase of product '{1}'.", customer, product));
        }
    }
}
