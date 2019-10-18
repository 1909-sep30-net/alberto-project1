using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library
{
    public class OrderDetails
    {
        public int product_id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int order_id { get; set; }
        public int Quantity { get; set; }


        public int ID { get; set; }

    }
}
