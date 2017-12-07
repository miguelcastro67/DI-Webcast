using System;
using System.Collections.Generic;
using System.Linq;

namespace DI.MVC
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetById(int id)
        {
            List<Customer> customers = GetAll();
            return customers.Where(item => item.Id == id).FirstOrDefault();
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>()
                {
                    new Customer() { Id = 1, Name = "Miguel A. Castro", Email = "miguel@melvicorp.com", Twitter = "@miguelcastro67" },
                    new Customer() { Id = 2, Name = "Chris Klug", Email = "chris@59north.com", Twitter = "@zerokoll" },
                };

            return customers;
        }

        public void Update(Customer customer)
        {
        }
    }
}