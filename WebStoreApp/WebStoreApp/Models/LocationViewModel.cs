using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApp.Models
{
    public class LocationViewModel
    {

        [Required]
        public int Id { get; set; }

        [DisplayName("Restuarant")]
        public string Name { get; set; }


    }
}
