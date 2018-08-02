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
        [HttpGet("api/Customers/Index")]
        public IEnumerable<Customer> Index()
        {
            return customerData.GetAllCustomers();
        }

        [HttpPost("api/Customers/Create")]
        public IActionResult Create([FromBody] Customer customer)
        {
            return Ok(customerData.AddCustomer(customer));
        }

        [HttpGet("api/Customers/Details/{id}")]
        public Customer Details(int id)
        {
            return customerData.GetCustomerData(id);
        }

        [HttpPut("api/Customers/Edit")]
        public IActionResult Edit([FromBody]Customer customer)
        {
            return Ok(customerData.UpdateCustomer(customer));
        }

        [HttpDelete("api/Customers/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(customerData.DeleteCustomer(id));
        }

    }
}