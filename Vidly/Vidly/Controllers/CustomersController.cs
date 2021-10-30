using System;
using System.Collections;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;
using vidly.Models;
using Vidly.Models;
using Vidly.ViewModels;
using System.Collections.Generic;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private movieDB _Context;
        public CustomersController()
        {
            _Context = new movieDB();
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Customer
        public ViewResult Index()
        {
            if (MemoryCache.Default["Genres"]==null)
            {
                MemoryCache.Default["Genres"] = _Context.genres.ToList();
            }
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            //var customers = _Context.customers.Include(c => c.membershipType).ToList();
            return View(/*customers*/);
        }
        public ActionResult Details(int id)
        {
            var customer = _Context.customers.Include(c => c.membershipType).SingleOrDefault(a => a.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public ActionResult New()
        {
            var viewmodl = new NewCustomerViewModel
            {
                customer=new Customer(),
                Membershiptypes = _Context.membershipTypes.ToList()
            };
            return View("New", viewmodl);
        }
        public ActionResult Edit(int id)
        {
            var customer = _Context.customers.Include(c => c.membershipType).SingleOrDefault(a => a.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewmodel = new NewCustomerViewModel
                {
                    customer = customer,
                    Membershiptypes = _Context.membershipTypes.ToList()
                };

                return View("New", viewmodel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (NewCustomerViewModel view)
        {
            var Ncustomer = view.customer;

            if (!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel
                {
                  customer=Ncustomer,
                  Membershiptypes=_Context.membershipTypes.ToList()
                };
                return View("New", viewmodel);
            }

            if (Ncustomer.Id == 0)
                {
                _Context.customers.Add(Ncustomer);
            }
            else
                {
                    var customerInDb = _Context.customers.Single(a => a.Id == Ncustomer.Id);
                    customerInDb.Name = Ncustomer.Name;
                    customerInDb.BirthDate = Ncustomer.BirthDate;
                    customerInDb.MembershipTypeId = Ncustomer.MembershipTypeId;
                    customerInDb.IsSubscribeToNewsLetter = Ncustomer.IsSubscribeToNewsLetter;
                }
            _Context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

      
        

          

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    { new Customer{Id=1,Name="John Smith"},
        //      new Customer{ Id=2,Name="marywilliams"} }; 
        //}
    }
}