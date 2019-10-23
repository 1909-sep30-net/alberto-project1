using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Library;
using Data.Access;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Models;

namespace WebStoreApp.Controllers
{
    //Location Controller controls the flow of listing the locations, listing the products, and placing the order.
    public class LocationController : Controller
    {
        private Repository _context;

        public LocationController(Repository repository)
        {
            _context = repository;
        }

        // Lists the locations
        public ActionResult Index()
        {
            List<Location> locations = _context.GetAllLocations();

            var viewModels = locations.Select(l => new LocationViewModel
            {
                Name = l.LocationName,
                Id = l.ID

            });
            return View(viewModels);
        }

        //List the products on the view
        public ActionResult ListProducts(int id)
        {


            List<Inventory> inventory = _context.GetInventoryforLocation(id);

            List<Customer> custs = _context.GetAllCustomers();


            OrderViewModel viewModel = new OrderViewModel
            {
                customerId = 0,
                customers = custs.Select(c => new CustomerViewModel
                {
                    Name = c.FirstName + " " + c.LastName,
                    Id = c.ID
                }).ToList(),

                inventory = inventory.Select(i => new InventoryViewModel
                {
                    Id = i.ID,
                    LocationId = i.location_id,
                    ProductId = i.product_id,
                    Stock = i.quantity,
                    Quantity = 0,



                }).ToList()
            };

            foreach (var item in viewModel.inventory)
            {
                item.ProdName = _context.GetProduct(item.ProductId).Name;
                item.Price = _context.GetProduct(item.ProductId).Price;
            }

            return View(viewModel);
        }

        // POST: Location/OrderDetails
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult OrderDetails(InventoryViewModel inventory)
        //{
        //    Order order = new Order(inventory.LocationId, 2);

        //    _context.AddNewOrder(order);
        //    order = _context.GetOrder(order);

        //    var viewmodel = new
        //    return RedirectToAction("ListProducts", "ProductsController", location);
        //}

        //Reviews order, products and quantity with the total.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReviewOrder(OrderViewModel order)
        {
            decimal total = 0;

            foreach (InventoryViewModel p in order.inventory)
            {
                total += p.Price * p.Quantity;

            }

            order.Total = total;

            return View(order);
        }

        //Submits the order into the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlaceOrder(OrderViewModel order)
        {
            Order o = new Order
            {
                CustomerID = order.customerId,
                LocationID = order.inventory[0].LocationId,
                Total = order.Total,
                Date = DateTime.Now

            };

            _context.AddNewOrder(o);
            _context.Save();

            Order newOrder = _context.GetOrder(o);


            foreach (var item in order.inventory)
            {
                if (item.Quantity > 0)
                {
                    Inventory inv = new Inventory
                    {
                        ID = item.Id,
                        product_id = item.ProductId,
                        location_id = item.LocationId,
                        quantity = item.Stock - item.Quantity,
                    };

                    _context.UpdateLocationInventory(inv);
                    _context.Save();

                    OrderDetails od = new OrderDetails
                    {
                        ID = 0,
                        order_id = newOrder.ID,
                        product_id = item.ProductId,
                        Quantity = item.Quantity
                    };

                    _context.AddNewOrderDetail(od);
                    _context.Save();
                }

            }
            
            return View();
        }



        //LOCATION CREATION FEATURE IN WORKS\\

        // GET: Location/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Location/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(LocationViewModel location)
        //{
        //    try
        //    {
        //        Location loc = new Location
        //        {
        //            LocationName = location.Name,
        //            ID = 0
                    
        //        };
        //        _context.AddNewLocation(loc);
        //        _context.Save();


        //        return RedirectToAction(nameof(Created));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////View for friendly
        //public ActionResult Created()
        //{
        //    return View();
        //}

        // GET: Location/Edit/5

        

       

      
        
    }
}