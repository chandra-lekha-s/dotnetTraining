using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class DesignationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DesignationController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var designations = await _db.Designation.ToListAsync();
            return View(designations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Designation designation)
        {
            if (ModelState.IsValid)
            {
                _db.Designation.Add(designation);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(designation);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var designation = await _db.Designation.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Designation designation)
        {
            if (id != designation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Entry(designation).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(designation);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var designation = await _db.Designation.FindAsync(id);
            if (designation == null)
            {
                return NotFound();
            }

            _db.Designation.Remove(designation);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
