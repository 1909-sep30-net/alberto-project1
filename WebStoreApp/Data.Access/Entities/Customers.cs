using System;
using System.Collections.Generic;

namespace Data.Access.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string User { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
