using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    public class PaymentRuleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentRuleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var paymentRules = await _context.PaymentRule.ToListAsync();
            return View(paymentRules);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentRule paymentRule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentRule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentRule);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentRule = await _context.PaymentRule.FindAsync(id);
            if (paymentRule == null)
            {
                return NotFound();
            }
            return View(paymentRule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentRule paymentRule)
        {
            if (id != paymentRule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(paymentRule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentRule);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var paymentRule = await _context.PaymentRule.FindAsync(id);
            if (paymentRule == null)
            {
                return NotFound();
            }

            _context.PaymentRule.Remove(paymentRule);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



    }
}
