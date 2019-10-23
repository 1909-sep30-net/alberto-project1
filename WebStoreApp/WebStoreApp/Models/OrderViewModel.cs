using Business.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApp.Models
{
    //Order Class Model for Views
    public class OrderViewModel
    {
        public List<InventoryViewModel> inventory { get; set; } = new List<InventoryViewModel>();

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public decimal Price { get; set; }

        public int locationId { get; set; }
        public int customerId { get; set; }
        public string locationName {get;set;}
        public DateTime Date { get; set; }

        public List<CustomerViewModel> customers = new List<CustomerViewModel>();
        
    }
}
