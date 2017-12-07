using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository;
        }

        ICustomerRepository _CustomerRepository;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            IEnumerable<Customer> customers = _CustomerRepository.GetAll();
            return View(customers);
        }

        public ActionResult Customer(int id)
        {
            Customer customer = _CustomerRepository.GetById(id);
            return View(customer);
        }
    }
}