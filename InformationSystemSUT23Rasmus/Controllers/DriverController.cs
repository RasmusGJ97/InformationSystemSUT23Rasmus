using InformationSystemSUT23Rasmus.Data;
using InformationSystemSUT23Rasmus.Models;
using InformationSystemSUT23Rasmus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace InformationSystemSUT23Rasmus.Controllers
{
    public class DriverController : Controller
    {
        private readonly AppDbContext _context;
        public DriverController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Get: Driver
        public async Task<IActionResult> AllDrivers(string searchDriver, string searchEmployee)
        {
            ViewData["DriverFilter"] = searchDriver;
            ViewData["EmployeeFilter"] = searchEmployee;

            var drivers = _context.Drivers
                .Include(d => d.Events)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchDriver) && !String.IsNullOrEmpty(searchEmployee))
            {
                drivers = drivers.Where(s => s.DriverName.Contains(searchDriver) && s.ResponsibleEmployee.Contains(searchEmployee));
            }
            else if (!String.IsNullOrEmpty(searchEmployee))
            {
                drivers = drivers.Where(s => s.ResponsibleEmployee.Contains(searchEmployee));
            }
            else if (!String.IsNullOrEmpty(searchDriver))
            {
                drivers = drivers.Where(s => s.DriverName.Contains(searchDriver));
            }

            var driverList = await drivers.ToListAsync();

            var driverBeloppList = driverList.Select(d => new DriverBeloppViewModel
            {
                Driver = d,
                TotalBeloppIn = d.Events.Sum(e => e.BeloppIn),
                TotalBeloppUt = d.Events.Sum(e => e.BeloppUt)
            }).ToList();

            return View(driverBeloppList);
        }


        //Get: Driver/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var driver = await _context.Drivers.Include(d => d.Events).FirstOrDefaultAsync(m => m.DriverID == id);

            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        // GET: Driver/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Driver());
        }

        // POST: Driver/Add
        [HttpPost]
        public async Task<IActionResult> Add([Bind("DriverName, CarReg, ResponsibleEmployee")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllDrivers));
            }
            return View(driver); // Returnera formuläret med eventuella valideringsfel
        }

        // GET: Driver/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var driver = await _context.Drivers.FirstOrDefaultAsync(e => e.DriverID == id);
            if (driver == null)
            {
                return NotFound(); 
            }
            return View(driver); 
        }

        // POST: Driver/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("DriverID, DriverName, CarReg, ResponsibleEmployee")] Driver driver)
        {
            if (id != driver.DriverID)
            {
                return NotFound(); // Kontrollera att ID:t matchar
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.DriverID))
                    {
                        return NotFound();
                    }
                    throw; // Annars kasta undantaget vidare
                }
                return RedirectToAction(nameof(AllDrivers));
            }
            return View(driver); // Returnera formuläret med eventuella valideringsfel
        }

        private bool DriverExists(int id)
        {
            return _context.Drivers.Any(e => e.DriverID == id);
        }

        //Get: Driver/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var driver = await _context.Drivers.FirstOrDefaultAsync(m => m.DriverID == id);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        //Post: Driver/Delete/1
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context.Drivers.FindAsync(id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllDrivers));
        }
    }
}
