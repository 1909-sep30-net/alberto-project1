using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library
{
    public class Inventory
    {
        public int location_id { get; set; }
        public int product_id { get; set; }
        public Product Product { get; set; }
        public Location Location { get; set; }
        public int quantity { get; set; }
        public int CostperUnit { get; set; }
        public string name { get; set; }
        public string description { get; set; }


        public int ID { get; set; }
    }
}
