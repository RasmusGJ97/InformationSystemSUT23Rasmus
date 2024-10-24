using InformationSystemSUT23Rasmus.Data;
using InformationSystemSUT23Rasmus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemSUT23Rasmus.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index() 
        { 
            return View(); 
        }

        public async Task<IActionResult> AllEvents(DateTime? startDate, DateTime? endDate, string searchString)
        {
            var events = from e in _context.Events
                         select e;
            if (startDate.HasValue && endDate.HasValue)
            {
                events = events.Where(e => e.NoteDate >= startDate && e.NoteDate <= endDate);
            }
            else if (startDate.HasValue)
            {
                events = events.Where(e => e.NoteDate >= startDate);
            }
            else if (endDate.HasValue)
            {
                events = events.Where(e => e.NoteDate <= endDate);
            }

            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");
            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Include(d => d.Driver).Where(s => s.Driver.DriverName.Contains(searchString));
            }

            return View(await events.Include(d => d.Driver).ToListAsync());
        }


        //Get: Event/Details/1
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var events = await _context.Events.Include(d => d.Driver).FirstOrDefaultAsync(m => m.EventID == id);

            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // GET: Event/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Event());
        }

        // POST: Event/Add
        [HttpPost]
        public async Task<IActionResult> Add([Bind("NoteDescription,NoteDate, BeloppIn, BeloppUt, DriverID")] Event events)
        {
            if (ModelState.IsValid)
            {
                var currentDateTime = DateTime.Now;
                events.NoteDate = events.NoteDate.Date.Add(currentDateTime.TimeOfDay);

                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AllEvents));
            }
            return View(events); // Returnera formuläret med eventuella valideringsfel
        }

        public async Task<IActionResult> NewEvents()
        {
            var events = from e in _context.Events
                         select e;
            DateTime startDate = DateTime.Now;
            if (HttpContext.Session.GetString("IsAdmin") == "Admin")
            {
                startDate = startDate.AddDays(-1);
            }
            else
            {
                startDate = startDate.AddHours(-12);
            }

            events = events.Where(e => e.NoteDate >= startDate);

            return View(await events.Include(d => d.Driver).ToListAsync());
        }
    }
}
