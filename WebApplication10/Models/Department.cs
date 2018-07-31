using System;
using System.Collections.Generic;

namespace WebApplication10.Models
{
    public partial class Department
    {
        public Department()
        {
            User = new HashSet<User>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public int ManagerId { get; set; }

        public Customer Customer { get; set; }
        public User ManagerNavigation { get; set; }
        public ICollection<User> User { get; set; }
    }
}
