using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public partial class Department
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int? ManagerUserId { get; set; }
        [NotMapped]
        public int tempdid { get; set; }
        [NotMapped]
        public int tempduid { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("ManagerUserId")]
        public virtual User Manager { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
