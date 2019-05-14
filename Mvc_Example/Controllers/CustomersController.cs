using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Example.Models;
using System.Data.Entity;
using Mvc_Example.View_Model;

namespace Mvc_Example.Controllers
{
    [RequireHttps]
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext dbContext = null;

        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            dbContext.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            
            List<Customer> customers = dbContext.Customers.Include(m => m.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(m =>m.MembershipType).SingleOrDefault(c => c.id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>() {
                new Customer {id=1,name="Haran",DateOfBirth=Convert.ToDateTime("15-12-1996")},
                new Customer{id=2,name="Hari",DateOfBirth=Convert.ToDateTime("11-12-1996")}
            };

            return customers;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel();
            Customer customer = new Customer();
            var membershipTypes = dbContext.MembershipTypes.ToList();
            viewModel.Customer = customer;
            viewModel.MembershipTypes = membershipTypes;
            return View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();//store in db
                                        //return View();
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                var membershipTypes = dbContext.MembershipTypes.ToList();
                CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel
                {
                    Customer = new Customer(),
                    MembershipTypes=membershipTypes,
                };
                return View(viewModel);
            }
            
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            
                var customer = dbContext.Customers.SingleOrDefault(c => c.id == id);
                var memTyped = dbContext.MembershipTypes.ToList();
                CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel
                {
                    Customer = customer,
                    MembershipTypes = memTyped
                };

                return View(viewModel);
            
            
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customertbl = dbContext.Customers.SingleOrDefault(c => c.id == customer.id);
                if (customertbl == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    customertbl.name = customer.name;
                    customertbl.DateOfBirth = customer.DateOfBirth;
                    customertbl.MembershipTypeid = customer.MembershipTypeid;
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index", "Customers");
            }
            else {
                var customer1 = dbContext.Customers.SingleOrDefault(c => c.id == customer.id);
                var memTyped = dbContext.MembershipTypes.ToList();
                CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel
                {
                    Customer = customer1,
                    MembershipTypes = memTyped
                };

                return View(viewModel);
            }
            
        }
    }
}