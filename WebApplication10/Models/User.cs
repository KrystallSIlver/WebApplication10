using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication10.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Mail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CustomerId { get; set; }
        public int? DepartmentId { get; set; }
        [NotMapped]
        public int tempuid { get; set; }
        [NotMapped]
        public int tempudid { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
