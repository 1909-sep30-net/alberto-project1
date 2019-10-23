using Business.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApp.Models
{
    //Order Details class model for views
    public class OrderDetailsViewModel
    {
        public string LocationName { get; set; }

        //Holds list of products for each order detail
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

        public int Quantity { get; set; }

        public string CustName { get; set; }

        public decimal Total { get; set; }

        public DateTime Date { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}
