using System;
using System.Collections.Generic;

namespace WebApplication10.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
