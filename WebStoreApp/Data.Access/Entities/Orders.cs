using System;
using System.Collections.Generic;

namespace Data.Access.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Locations Location { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
