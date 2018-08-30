using System;
using System.Collections.Generic;

namespace WebApplication10.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Contacts = new HashSet<Contact>();
            Departments = new HashSet<Department>();
            Users = new HashSet<User>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public string Type { get; set; }
        public int? NumberOfSchools { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
