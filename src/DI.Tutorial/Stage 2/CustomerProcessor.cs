using System;
using System.Linq;

namespace DI.Tutorial.Stage2
{
    public class CustomerProcessor : ICustomerProcessor
    {
        public CustomerProcessor(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _CustomerRepository = customerRepository;
            _ProductRepository = productRepository;
        }

        ICustomerRepository _CustomerRepository;
        IProductRepository _ProductRepository;

        void ICustomerProcessor.UpdateCustomerOrder(string customer, string product)
        {
            _CustomerRepository.Save();
            _ProductRepository.Save();

            Console.WriteLine(string.Format("Customer record for '{0}' updated with purchase of product '{1}'.", customer, product));
        }
    }

    public interface ICustomerProcessor
    {
        void UpdateCustomerOrder(string customer, string product);
    }
}
