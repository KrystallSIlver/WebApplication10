using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.Models
{
    public class FullData
    {
        public Customer customer { get; set; }
        public List<int> contactstodelete { get; set; }
        public List<int> depstodelete { get; set; }
        public List<int> userstodelete { get; set; }
        public bool contactchecker { get; set; }
        public Contact contact { get; set; }
    }
}
