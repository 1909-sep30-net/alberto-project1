﻿using Data.Access.Entities;
using System;
using System.Linq;
using Business.Library;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Access
{
    public class Repository : IDisposable
    {
        private readonly Store2Context _context;

        public Repository(Store2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void AddCustomer(Business.Library.Customer customer)
        {


            Entities.Customers entity = Mapper.MapCustomer(customer);
            _context.Add(entity);

        }

        public void RemoveCustomer(Business.Library.Customer customer)
        {
            Entities.Customers entity = Mapper.MapCustomer(customer);
            _context.Remove(entity);
        }

        public List<Business.Library.Customer> GetAllCustomers()
        {

            List<Entities.Customers> customers = _context.Customers.Include(c => c).ToList();


            return customers.Select(Mapper.MapCustomer).ToList();
        }
        public Customer GetCustomer(int id)
        {
            try
            {
                var customer = Mapper.MapCustomer(_context.Customers.Single(c => c.Id == id));

                return customer;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Customer GetCustomerByName(string firstname, string lastname)
        {
            try
            {
                var customer = Mapper.MapCustomer(_context.Customers.Single(c => c.FirstName == firstname && c.LastName == lastname));

                return customer;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public void AddNewOrder(Order order)
        {
            Entities.Orders entity = Mapper.MapOrder(order);
            try
            {
                _context.Add(entity);
            }
            catch (Exception)
            {
                return;
            }
        }

        public bool AddNewLocation(Location location)
        {
            Locations entity = Mapper.MapLocation(location);
            try
            {
                
                _context.Add(entity);
                return true;
            }
            catch (ArgumentNullException)
            {

                return false;
            }
        }
        public Order GetOrder(Order order)
        {
            var entity = _context.Orders.Single(o => o.CreatedAt == order.Date);
            var newOrder = Mapper.MapOrder(entity);
            return newOrder;
        }
        //public List<Business.Library.Product> GetInv(int id)
        //{
        //    List<Entities.Inventory> products = _context.Inventory
        //        .Include(i => i.Product).ToList();

        //    products = products.Where(p => p.LocationId == id).ToList();

        //    return products.Select(Mapper.MapInv).ToList();
        //}

        public List<Business.Library.Location> GetAllLocations()
        {

            List<Entities.Locations> locations = _context.Locations.Include(c => c).ToList();


            return locations.Select(Mapper.MapLocation).ToList();
        }

        public void UpdateLocationInventory(Business.Library.Inventory inventory)
        {
            Entities.Inventory myEntity = _context.Inventory.Find(inventory.ID);
            Entities.Inventory newEntity = Mapper.MapInv(inventory);
            _context.Entry(myEntity).CurrentValues.SetValues(newEntity);
        }

        public void FindCustomerByID(int id)
        {

        }
        public List<Business.Library.Order> GetOrders(int id)
        {
            List<Entities.Orders> order = _context.Orders.Include(c => c.Customer).ToList();
            order = order.Where(c => c.CustomerId == id).ToList();
            return order.Select(Mapper.MapOrder).ToList();
        }

        public List<Business.Library.OrderDetails> GetOrderDetais(Order order)
        {
            List<Entities.OrderDetails> details = _context.OrderDetails.Include(r => r.Product).ToList();
            details = details.Where(i => i.OrderId == order.ID).ToList();

            return details.Select(Mapper.MapOrderDetails).ToList();
        }
        public void UpdateCartForOrder(Business.Library.OrderDetails order)
        {
            Entities.OrderDetails myEntity = _context.OrderDetails.Find(order.ID);
            Entities.OrderDetails newEntity = Mapper.MapOrderDetails(order);
            _context.Entry(myEntity).CurrentValues.SetValues(newEntity);
        }

        public void AddNewOrderDetail(Business.Library.OrderDetails order)
        {
            Business.Library.OrderDetails od = new Business.Library.OrderDetails
            {

                order_id = order.order_id,
                product_id = order.product_id,
                Quantity = order.Quantity,
                //Product = product,
                //Order = order
            };
            Entities.OrderDetails entity = Mapper.MapOrderDetails(od);
            _context.Add(entity);
        }

        public Product GetProduct(int id)
        {
            Products entity = _context.Products.First(p => p.Id == id);

            Product product = Mapper.MapProduct(entity);
            return product;
        }
        public List<Product> GetAllProductsByOrderDetail(Business.Library.OrderDetails od)
        {
            List<Products> entity = _context.Products.Include(p => p.OrderDetails).ToList();
            entity = entity.Where(p => p.Id == od.product_id).ToList();

            return entity.Select(Mapper.MapProduct).ToList();
        }



        public Location GetLocationByID(int id)
        {
            Entities.Locations entity = _context.Locations.Single(l => l.Id == id);
            Location location = Mapper.MapLocation(entity);
            return location;
        }
        public List<Business.Library.OrderDetails> GetCurrentCart(Order order)
        {
            List<Entities.OrderDetails> cart = _context.OrderDetails.Include(r => r.Product).ToList();
            cart = cart.Where(i => i.OrderId == order.ID).ToList();

            return cart.Select(Mapper.MapOrderDetails).ToList();
        }

        public List<Business.Library.Inventory> GetInventoryforLocation(int id)
        {

            List<Entities.Inventory> inventory = _context.Inventory.Include(r => r.Product).ToList();
            inventory = inventory.Where(i => i.LocationId == id).ToList();

            return inventory.Select(Mapper.MapInv).ToList();
        }


        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
