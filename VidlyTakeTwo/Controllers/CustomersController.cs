using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using VidlyTakeTwo.Models;
using VidlyTakeTwo.ViewModels;

namespace VidlyTakeTwo.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;//Here is our interface to the db

        public CustomersController()
        {
            _context = new ApplicationDbContext();//Instantiating the context in constructor
        }
        //The DbCOntext is DISPOSABLE OBJECT. The proper way to dispose of it is to override the Dispose() method
        //of the base conroller class. SEE BELOW

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
         {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();//Customers is a DBSET defined in our Db Context
 //Include() is an example of Eager Loading; pulling in all the info we need before moving to the View.
             return View(customers);
         }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);//LINQ and LAMBDA
 //REMEMBER IF FILTERING, CONSIDER LINQ BEFORE FOREACH LOOPS
             if (customer == null)
                 return HttpNotFound();
 
            return View(customer);
        }
    }
}