using System;
using System.Linq;

namespace DI.Tutorial.Stage3
{
    public class CustomerRepository : ICustomerRepository
    {
        void ICustomerRepository.Save()
        {
            Console.WriteLine("Customer purchase saved.");
        }
    }

    public interface ICustomerRepository
    {
        void Save();
    }
}
