using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library
{
    public class Product
    {
        private string _name;
        private string _description;
        private int _amount;
        private decimal _price;

        public int ID { get; set; }
        public string Name
        {
            get => this._name;
        }

        public string Description
        {
            get => this._description;
        }

        public int Amount
        {
            get => this._amount;
            set => this._amount = value;
        }

        public decimal Price 
        { 
            get => _price; 
            set => this._price = value; 
        }

        public Product() { }

        public Product(string name, string description, decimal price)
        {
            if(name.Length == 0) 
            {
                throw new ArgumentException("Product name is empty.");
            }
            else if (description.Length == 0)
            {
                throw new ArgumentException("Product description is empty.");
            }
            else if (price == 0)
            {
                throw new ArgumentException("There is no price set");
            }
            else if (price == 0)
            {
                throw new ArgumentException("There is no price set");
            }
            else
            {
                this._name = name;
                this._description = description;
                this._price = price;
            }
        }
    }
}
