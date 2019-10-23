using System;

namespace Business.Library
{
    public class Customer
    {
        private string _firstname;
        private string _lastname;

        public Customer() { }
        public Customer(string fname, string lname)
        {
            if ((fname.Length == 0) || (lname.Length == 0))
            {
                throw new ArgumentException("Please enter first and last name.");
            }
            else
            {
                FirstName = fname;
                LastName = lname;
            }
        }

        public string Customername 
        { 
            get { return FirstName + " " + LastName; }
            //set { this._firstname = value; }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string User { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }





    }
}
