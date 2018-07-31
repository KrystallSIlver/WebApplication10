using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [Produces("application/json")]
    public class CustomersController : Controller
    {
        CustomerDataAccessLayer customerData = new CustomerDataAccessLayer();
        [HttpGet]
        [Route("api/Customers/Index")]
        public IEnumerable<Customer> Index()
        {
            return customerData.GetAllCustomers();
        }

        [HttpPost("api/Customers/Create")]
        public IActionResult Create([FromBody] Customer customer)
        {
            return Ok(customerData.AddCustomer(customer));
        }

        [HttpGet]
        [Route("api/Customers/Details/{id}")]
        public Customer Details(int id)
        {
            return customerData.GetCustomerData(id);
        }

        [HttpPut]
        [Route("api/Customers/Edit")]
        public int Edit([FromBody]Customer customer)
        {
            return customerData.UpdateCustomer(customer);
        }

        [HttpDelete]
        [Route("api/Customers/Delete/{id}")]
        public int Delete(int id)
        {
            return customerData.DeleteCustomer(id);
        }

    }
}