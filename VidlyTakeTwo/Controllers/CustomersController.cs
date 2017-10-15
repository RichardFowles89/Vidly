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
        {//we removed the below once we added jquery the the view. It calls our api making this code
            //redundant
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();//Customers is a DBSET defined in our Db Context
            //                                                                           //Include() is an example of Eager Loading; pulling in all the info we need before moving to the View.
            //return View(customers);

            return View();
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
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),//Initalising the Customer sets its ID to 0, giving it a value
                MembershipTypes = membershipTypes
            };
//The corresponding view for this action was originally called 'New' like the action. We changed this
//to 'CustomerForm'. Consequently, we now have to pass the name of the form in the View() to tell it
//where to go
            return View("CustomerForm", viewModel);
        }
//Best practice - if an action modifies data, they should never be accessable via HttpGet
        [HttpPost]//This attribute ensures that this action can only be called using HttpPost, not HttpGet
        [ValidateAntiForgeryToken]//This corresponds with the method in CustomerForm. It checks that the token left in the user's browser matches the token that is added to the form as a hidden field by the method
        public ActionResult Save(Customer customer)
        {//First we check that the properties in customer are valid. By this, I mean things like: Is the
            //Name less than 255 chars - this requirement is set in the model using data annotations
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {//If the model state is not valid, we return the view we were just on
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)//If it's a new customer
            _context.Customers.Add(customer);//This just adds the customer to memory
            else
            {//If it's not a new customer then we need to edit the existing record. So first, read it in...
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //We could use the method TryUpdateModel() here but Mosh does not recommend it

                customerInDb.Name = customer.Name;//Here we are editing the data
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();//THIS is where the data is written to the db
            return RedirectToAction("Index", "Customers");//Finally, we go back to the Customers page
        }

//Because MVC framework is really smart, it will automatically map request data to the object set as
//the parameter - the parameter needs to be the model behind the View. This is called MODEL BINDING.
//In the lecture, we start by putting NewCustomerViewModel as the parameter. But, the Mosh, changes
//it to Customer. MVC is smart enough to bind Customer, rather than NewCustomerViewModel, to the 
//request data because all of the keys in the form data are prefixed by 'Customer'.
//Mosh does a cool demo of this in the lecture 'Model Binding'.

        public ActionResult Edit(int id)//Allows us to edit an existing customer
        {//In order to edit a record, it first has to be retreived from the db...
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //If no customer has that ID in the db...
            if(customer == null)
            {//...return Http Not Found
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel//This is the model we need to pass to 'CustomerForm'
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);//The first arg here overrides the default convention
//Rather than going to a View with the same name as the method, the arg is telling the View() method
//to go to a View called CustomerForm
        }

    }
}