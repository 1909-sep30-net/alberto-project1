using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Library
{
    public class Location
    {
        private string _name;

        private Product item = null;

        public int ID { get; set; }
        public string LocationName
        {
            get => this._name; set => LocationName = value;
        }


        public List<Inventory> Inventory { get; set; } = new List<Inventory> { };


        public Location() { }
        public Location(string name)
        {
            if (name.Length == 0)
            {
                throw new ArgumentException("Location name is invalid.");
            }
            else
                this._name = name;


        }

        public int Quantity(Inventory product)
        {
            //item = new Product(product.Name, product.Description, product.Price);
            int index = Inventory.IndexOf(product);
            try
            {
                return product.quantity;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Index is {index}!!!!!!!");
                return -1;
            }
        }

        public bool AddItem(Product product, int quantity)
        {
            //item = new Product(product.Name, product.Description, product.Price);
            //int index;

            //if (Inventory.Contains(item))
            //{
            //    index = Inventory.IndexOf(item);
            //    Inventory[index].Amount += quantity;
            //    return true;
            //}
            //else
            //{
            //    Inventory.Add(item);
            //    index = Inventory.IndexOf(item);
            //    Inventory[index].Amount+= quantity;
            //    return true;
            //}
            return true;

        }

        //public bool RemoveItem(Inventory item, int quantity, Repository data)
        //{
        //    //item = new Product(product.Name, product.Description, product.Price);
        //    int index = Inventory.IndexOf(item.Product);
        //    if (index == -1)
        //    {
        //        throw new ArgumentException($"Item {item.Name} is not found in inventory.");
        //    }
        //    else if (Inventory[index].Amount < quantity)
        //    {
        //        throw new ArgumentException($"Cannot remove the amount requested.");

        //    }
        //    else if (Inventory[index].Amount == 1)
        //    {
        //        Inventory.Remove(item);
        //        return true;
        //    }
        //    else
        //    {
        //        Inventory[index].Amount -= quantity;
        //        return true;
        //    }
        //    return true;

        //}




    }
}
