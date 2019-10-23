using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreApp.Models
{
    // in MVC, the "model" doesn't depend on the view.....
    // but MVC views do need a model that has all the data they need to display
    // sometimes those needs clash.
    // so often we will make a new model class that is tightly coupled to the view,
    // gives all the things that view needs.
    // in this case, we call that new class a view model.
    public class CustomerViewModel
    {
        [DisplayName("ID")] // this one is associated with the Html.DisplayNameFor helper
        public int Id { get; set; }

        //[DisplayFormat(] // there are attributes like Display and DisplayFormat
        // to modify here in this one place how values in this property will be displayed in some view
        // (when we use the Html.DisplayFor HTML helper!)
        [Required] // can't be null or empty string
        public string firstName { get; set; }

        // in ASP.NET, client-side validation is driven by DataAnnotations attributes like these
        //   in combination with jquery Validation library, and the tag helpers for input and validation span.

        // server-side validation is driven by the same properties, which are checked during model binding
        // and erors are put into ModelState. you do have to write the code ot check ModelState.
        [Required]
        public bool LoggedIn { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string password { get; set; }

        
        public string User { get; set; }

       
        public string Name { get; set; }

        //Used for getting list of customers
        public List<CustomerViewModel> customers = new List<CustomerViewModel>();



        //[Required]
        //public List<string> Types { get; set; }
    }
}
