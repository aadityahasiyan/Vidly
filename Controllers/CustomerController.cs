using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        //private static List<Customer> customers = new List<Customer>() { new Customer { Id = 1, Name = "John Smith" }, new Customer { Id = 2, Name = "Mary Williams" } };
        private MovieRentalDBContext _context;
        public CustomerController()
        {
            _context = new MovieRentalDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(customers => customers.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var vm = new NewCustomerViewModel
            {
                Customer =  new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm",vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var vm = new NewCustomerViewModel
                {
                    Customer = customer, MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", vm);
            }

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null) { return HttpNotFound(); }
            var vm = new NewCustomerViewModel
            {
                Customer = customer, MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", vm);
        }
    }
}