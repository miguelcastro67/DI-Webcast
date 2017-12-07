using System;
using System.Linq;

namespace DI.Tutorial.Stage3
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository(ILogger logger)
        {
            _Logger = logger;
        }

        ILogger _Logger;

        void ICustomerRepository.Save()
        {
            _Logger.Log("This is CustomerRepository logger.");
            Console.WriteLine("Customer purchase saved.");
        }
    }

    public interface ICustomerRepository
    {
        void Save();
    }
}
