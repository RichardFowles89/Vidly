using System.Data.Entity;
using System.Linq;
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
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);//LINQ and LAMBDA
                                                                                                              //REMEMBER IF FILTERING, CONSIDER LINQ BEFORE FOREACH LOOPS
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()//For adding new Customers
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }
//Best practice - if an action modifies data, they should never be accessable via HttpGet
        [HttpPost]//This attribute ensures that this action can only be called using HttpPost, not HttpGet
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);//This just adds the customer to memory
            _context.SaveChanges();//THIS is where the data is written to the db
            return RedirectToAction("Index", "Customers");//Finally, we go back to the Customers page
        }

//Because MVC framework is really smart, it will automatically map request data to the object set as
//the parameter - the parameter needs to be the model behind the View. This is called MODEL BINDING.
//In the lecture, we start by putting NewCustomerViewModel as the parameter. But, the Mosh, changes
//it to Customer. MVC is smart enough to bind Customer, rather than NewCustomerViewModel, to the 
//request data because all of the keys in the form data are prefixed by 'Customer'.
//Mosh does a cool demo of this in the lecture 'Model Binding'.
    }
}