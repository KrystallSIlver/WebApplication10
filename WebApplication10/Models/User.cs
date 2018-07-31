using System;
using System.Collections.Generic;

namespace WebApplication10.Models
{
    public partial class User
    {
        public User()
        {
            DepartmentNavigation = new HashSet<Department>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public string Department { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
        public int DepartmentId { get; set; }

        public Customer Customer { get; set; }
        public Department Department1 { get; set; }
        public ICollection<Department> DepartmentNavigation { get; set; }
    }
}
