using InformationSystemSUT23Rasmus.Data;
using InformationSystemSUT23Rasmus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemSUT23Rasmus.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(Employee loginModel)
        {
            var employee = _context.Employees
                .FirstOrDefault(e => e.Email == loginModel.Email && e.Password == loginModel.Password);

            if (employee != null)
            {
                // Spara information om användaren i sessionen
                HttpContext.Session.SetString("CurrentUserId", employee.EmployeeID.ToString());
                HttpContext.Session.SetString("IsAdmin", employee.Role.ToString());

                return RedirectToAction("Index"); // Gå till Index eller önskad vy
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your Email and Password.");
            return View(loginModel);
        }

        // Logga ut
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Rensa sessionen
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            return View();
        }

        //Get: Employee
        public async Task<IActionResult> AllEmployees(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var employees = from d in _context.Employees
                          select d;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Name.Contains(searchString));
            }

            return View(await employees.ToListAsync());
        }

        //Get: Employee/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employee/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Employee()); // Returnera en ny anställd
        }

        // POST: Employee/Add
        [HttpPost]
        public async Task<IActionResult> Add([Bind("Name, Email, Password, Role")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllEmployees));
            }
            return View(employee); // Returnera formuläret med eventuella valideringsfel
        }

        // GET: Employee/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (employee == null)
            {
                return NotFound(); // Returnera NotFound om ingen anställd hittas
            }
            return View(employee); // Returnera den anställde för redigering
        }

        // POST: Employee/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID, Name, Email, Password, Role")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound(); // Kontrollera att ID:t matchar
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return NotFound(); // Kontrollera om anställd finns vid redigering
                    }
                    throw; // Annars kasta undantaget vidare
                }
                return RedirectToAction(nameof(AllEmployees));
            }
            return View(employee); // Returnera formuläret med eventuella valideringsfel
        }

        // Kontrollera om en anställd finns
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }

        //Get: Employee/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        //Post: Employee/Delete/1
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AllEmployees));
        }
    }
}
