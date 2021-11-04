using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.DAL;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : Controller
    {
        private readonly PharmacyDbContext _context;

        public PharmaciesController(PharmacyDbContext context)
        {
            _context = context;
        }

        // GET: Pharmacies/all
        [Route("getPharmacies")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Pharmacies.ToListAsync());
        }

        // GET: Pharmacies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies
                .FirstOrDefaultAsync(m => m.IdPharmacy == id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        // GET: Pharmacies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pharmacies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPharmacy,NamePharmacy,ApiKeyPharmacy,Endpoint")] Pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacy);
        }

        // GET: Pharmacies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            return View(pharmacy);
        }

        // POST: Pharmacies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPharmacy,NamePharmacy,ApiKeyPharmacy,Endpoint")] Pharmacy pharmacy)
        {
            if (id != pharmacy.IdPharmacy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmacy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PharmacyExists(pharmacy.IdPharmacy))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacy);
        }

        // GET: Pharmacies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies
                .FirstOrDefaultAsync(m => m.IdPharmacy == id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        // POST: Pharmacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            _context.Pharmacies.Remove(pharmacy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PharmacyExists(string id)
        {
            return _context.Pharmacies.Any(e => e.IdPharmacy == id);
        }
    }
}
