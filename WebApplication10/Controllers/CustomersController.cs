using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpGet("api/Login")]
        public IActionResult Login([FromBody] Login user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            if (user.UserName=="admin" && user.Password == "admin")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("api/Customers/Create")]
        public IActionResult Create([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(customerData.AddCustomer(customer));
        }

        [HttpGet("api/Customers/Details/{id}")]
        public Customer Details(int id)
        {
            return customerData.GetCustomerData(id);
        }

        [HttpPut("api/Customers/Edit")]
        public IActionResult Edit([FromBody]FullData customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(customerData.UpdateCustomer(customer));
        }

        [HttpDelete("api/Customers/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(customerData.DeleteCustomer(id));
        }

    }
}