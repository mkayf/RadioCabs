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

            Console.WriteLine("Form submitted");

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

            return View("Listings");
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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
