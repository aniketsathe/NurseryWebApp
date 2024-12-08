using NurseryWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NurseryWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Dashboard()
        {
            if (!(Session["Username"] != null))
            {
                return RedirectToAction("Login", "Account");
            }
            // Mock data - replace with actual database calls
            ViewBag.TotalRevenue = "-2500.00 ₹";
            ViewBag.YearlyRevenue = "-2500.00 ₹";
            ViewBag.MonthlyRevenue = "-2500.00 ₹";
            ViewBag.DailyRevenue = "0.00 ₹";

            ViewBag.TotalSales = "0.00 ₹";
            ViewBag.YearlySales = "0.00 ₹";
            ViewBag.MonthlySales = "0.00 ₹";
            ViewBag.DailySales = "0.00 ₹";

            ViewBag.TotalPurchase = "2500.00 ₹";
            ViewBag.YearlyPurchase = "2500.00 ₹";
            ViewBag.MonthlyPurchase = "2500.00 ₹";
            ViewBag.DailyPurchase = "0.00 ₹";

            ViewBag.TotalExpenses = "2500.00 ₹";
            ViewBag.YearlyExpenses = "2500.00 ₹";
            ViewBag.MonthlyExpenses = "2500.00 ₹";
            ViewBag.DailyExpenses = "0.00 ₹";

            ViewBag.TotalBookings = "2500.00 ₹";
            ViewBag.YearlyBookings = "2500.00 ₹";
            ViewBag.MonthlyBookings = "2500.00 ₹";
            ViewBag.DailyBookings = "0.00 ₹";

            return View();
        }
        public ActionResult GetCustomerList()
        {
            // Mock data
            var customers = new List<Customer>();
            customers = new List<Customer>
            {
                new Customer()
                {
                    CustomerName = "Aniket Sathe",
                    Address = "Akluj",
                    MobileNumber = 987654321,
                    EmailID = "abc@gmail.com",
                    Gender = "Male"                    
                },
                new Customer()
                {
                    CustomerName = "Aniket Sathe",
                    Address = "Akluj",
                    MobileNumber = 987654321,
                    EmailID = "abc@gmail.com",
                    Gender = "Male"
                },
                new Customer()
                {
                    CustomerName = "Aniket Sathe",
                    Address = "Akluj",
                    MobileNumber = 987654321,
                    EmailID = "abc@gmail.com",
                    Gender = "Male"
                },
            };

            return View(customers);
        }

        // GET: Customer/Create
        public ActionResult CreateCustomer()
        {
            return View(); // This will return the form view
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {                
                return RedirectToAction("Success"); // Redirect to a success page or action.
            }
            return View(customer); // If validation fails, return to the form.
        }

        // GET: Customer/Success
        public ActionResult Success()
        {
            return View(); // A success message or page
        }
    }
}