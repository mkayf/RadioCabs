using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadioCabs.Models;

namespace RadioCabs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RadioCabsDbContext _context;


        public HomeController(ILogger<HomeController> logger, RadioCabsDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listings()
        {
            var companies = _context.Companies.ToList();
            return View(companies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Listings
            (Company company)
        {


            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = "Please fill in all required fields.";
                TempData["AlertType"] = "danger";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    company.CreatedAt = DateTime.Now;

                    _context.Companies.Add(company);
                    _context.SaveChanges();

                    TempData["AlertMessage"] = "Company registered successfully!";
                    TempData["AlertType"] = "success";

                    return RedirectToAction("Listings");
                }
                catch (DbUpdateException ex)
                {
                    TempData["AlertMessage"] = $"Error: {ex.Message}";
                    TempData["AlertType"] = "danger";

                    ModelState.AddModelError("", $"Database error: {ex.InnerException?.Message}");
                }
                catch (Exception ex)
                {   
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }

            var companies = _context.Companies.ToList();
            return View("Listings", companies);
        }


        public IActionResult CompanyFullDetails(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);

            if (company == null) {
                return NotFound();
            }

            return View(company);
        }


        public IActionResult Drivers()
        {
            var drivers = _context.Drivers.ToList();
            return View(drivers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Drivers(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); 
                }

            }

            if (ModelState.IsValid)
            {
                try
                {
                    driver.CreatedAt = DateTime.Now;
                    _context.Drivers.Add(driver);
                    _context.SaveChanges();
                    TempData["AlertMessage"] = "Driver registered successfully!";
                    TempData["AlertType"] = "success";

                    return RedirectToAction("Drivers");
                }
                catch (DbUpdateException ex)
                {
                    TempData["AlertMessage"] = $"Error: {ex.Message}";
                    TempData["AlertType"] = "danger";

                    ModelState.AddModelError("", $"Database error: {ex.InnerException?.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }

            var drivers = _context.Drivers.ToList();
            return View("Drivers", drivers);

        }

        public IActionResult DriverFullDetails(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(d => d.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
