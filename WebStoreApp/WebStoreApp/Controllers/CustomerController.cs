using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Library;
using Data.Access;
using WebStoreApp.Models;

namespace WebStoreApp.Controllers
{
    //Customer Controller controls the flow for Creating and seeing a customer's order history
    public class CustomerController : Controller
    {
        private  Repository _context;

        public CustomerController(Repository repository)
        {
            _context = repository;
        }

        // GET: Customer
        public ActionResult Index(CustomerViewModel viewModel)
        {
            List<Customer> customers = _context.GetAllCustomers();

            List<CustomerViewModel> custs = customers.Select(c => new CustomerViewModel
            {
                Name = c.FirstName + " " + c.LastName,
                Id = c.ID
            }).ToList();

            CustomerViewModel view = new CustomerViewModel
            {
                customers = custs
            };
            
            return View(view);
        }

        public ActionResult CustNotFound()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderHistory(CustomerViewModel view)
        {
            Customer customer = _context.GetCustomerByName(view.firstName, view.lastName);
            
            if (customer == null)
            {
                return RedirectToAction(nameof(CustNotFound));
            }
            
            List<Order> orders = _context.GetOrders(customer.ID);


            List<OrderDetailsViewModel> ods = new List<OrderDetailsViewModel>();
            
            
            foreach (Order order in orders)
            {
                List<ProductViewModel> viewProducts = new List<ProductViewModel>();

                List<Business.Library.OrderDetails> od = _context.GetOrderDetais(order);
                foreach (OrderDetails o in od)
                {


                    
                    ProductViewModel prod = new ProductViewModel
                        {
                            Name = o.Product.Name,
                            Description = o.Product.Description,
                            Price = o.Product.Price,
                            Quantity = o.Quantity
                        };
                        viewProducts.Add(prod);
                    
                    
                }
                OrderDetailsViewModel detail = new OrderDetailsViewModel
                {
                    CustName = customer.FirstName + " " + customer.LastName,
                    LocationName = _context.GetLocationByID(order.LocationID).LocationName,
                    Products = viewProducts,
                    Date = order.Date,
                    Total = order.Total
                };
                ods.Add(detail);
            }
            
           
        

            
            return View(ods);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel view)
        {
            try
            {
                Customer customer = new Customer
                {
                    FirstName = view.firstName,
                    LastName = view.lastName,
                    ID = 0,
                    User = "Test",
                    Password = "Test"
                };
                _context.AddCustomer(customer);
                _context.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        //LOGIN FEATURE IN THE WORKS\\
       
        //public ActionResult Login()
        //{
        //    return View();
        //}

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(CustomerViewModel view)
        //{
            
        //    try
        //    {
        //        Customer customer = new Customer("Test", "test");

        //        var viewModel = new CustomerViewModel
        //        {
        //            Id = customer.ID,
        //            Name = customer.FirstName + " " + customer.LastName,
        //            LoggedIn = true
        //        };

        //        ViewData["Name"] = "Hello?";

        //        return RedirectToAction("Index", viewModel);
        //    }
        //    catch
        //    {
        //        view.LoggedIn = false;
        //        return View(view);
        //    }
        //}
        
        //// GET: Customer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}


        //// POST: Customer/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}