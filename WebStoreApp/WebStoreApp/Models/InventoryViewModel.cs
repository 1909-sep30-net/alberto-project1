using Business.Library;
using Data.Access.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApp.Models
{
    //Inventory class model for views
    public class InventoryViewModel
    {
       
        public int Id { get; set; }
        
        public int LocationId { get; set; }
        
        public int ProductId { get; set; }
        
        public int Stock { get; set;}

        public int Quantity { get; set; }

        public string ProdName { get; set; }

        public decimal Price { get; set; }

        //public virtual Location Location { get; set; } = new Location();

        //public virtual Product Product { get; set; } = new Product();
            


    }
}
