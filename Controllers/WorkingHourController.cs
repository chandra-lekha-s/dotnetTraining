using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class WorkingHourController : Controller
    {
        private readonly ApplicationDbContext _db;

        public WorkingHourController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var workingHours = await _db.WorkingHour.ToListAsync();
            return View(workingHours);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkingHour workingHour)
        {
            if (ModelState.IsValid)
            {
                _db.WorkingHour.Add(workingHour);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workingHour);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var workingHour = await _db.WorkingHour.FindAsync(id);
            if (workingHour == null)
            {
                return NotFound();
            }
            return View(workingHour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkingHour workingHour)
        {
            if (id != workingHour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Entry(workingHour).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workingHour);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var workingHour = await _db.WorkingHour.FindAsync(id);
            if (workingHour == null)
            {
                return NotFound();
            }

            _db.WorkingHour.Remove(workingHour);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
