using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Employee> employees = await _db.Employees
                .Include(e=>e.Designation)
                .Include(e=>e.PaymentRule)
                .Include(e=>e.WorkingHour)
                .ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var designations = await _db.Designation.ToListAsync();
            ViewBag.Designations = new SelectList(designations, "Id", "Name");

            var workingHours = await _db.WorkingHour.ToListAsync();
            ViewBag.WorkingHours = new SelectList(workingHours, "Id", "EmployeeMonthlyWorkingHour");

            var paymentRules = await _db.PaymentRule.ToListAsync();
            ViewBag.PaymentRules = new SelectList(paymentRules, "Id", "RuleName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index"); // Replace "Index" with the appropriate action to redirect after successful employee creation
            }
            else
            {
                ViewBag.Designations = null;
                var designations = await _db.Designation.ToListAsync();
                ViewBag.Designations = new SelectList(designations, "Id", "Name");

                var workingHours = await _db.WorkingHour.ToListAsync();
                ViewBag.WorkingHours = new SelectList(workingHours, "Id", "EmployeeMonthlyWorkingHour");

                var paymentRules = await _db.PaymentRule.ToListAsync();
                ViewBag.PaymentRules = new SelectList(paymentRules, "Id", "RuleName");
                return View(employee);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var designations = await _db.Designation.ToListAsync();
            ViewBag.Designations = new SelectList(designations, "Id", "Name", employee.DesignationId);

            var workingHours = await _db.WorkingHour.ToListAsync();
            ViewBag.WorkingHours = new SelectList(workingHours, "Id", "EmployeeMonthlyWorkingHour", employee.WorkingHourId);

            var paymentRules = await _db.PaymentRule.ToListAsync();
            ViewBag.PaymentRules = new SelectList(paymentRules, "Id", "RuleName", employee.PaymentRuleId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Load the associated entities from the database
                employee.Designation = await _db.Designation.FindAsync(employee.DesignationId);
                employee.WorkingHour = await _db.WorkingHour.FindAsync(employee.WorkingHourId);
                employee.PaymentRule = await _db.PaymentRule.FindAsync(employee.PaymentRuleId);

                _db.Entry(employee).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var designations = await _db.Designation.ToListAsync();
            ViewBag.Designations = new SelectList(designations, "Id", "Name", employee.DesignationId);

            var workingHours = await _db.WorkingHour.ToListAsync();
            ViewBag.WorkingHours = new SelectList(workingHours, "Id", "EmployeeMonthlyWorkingHour", employee.WorkingHourId);

            var paymentRules = await _db.PaymentRule.ToListAsync();
            ViewBag.PaymentRules = new SelectList(paymentRules, "Id", "RuleName", employee.PaymentRuleId);

            return View(employee);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
