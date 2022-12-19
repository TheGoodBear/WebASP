using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVMVC_EF.Data;
using MVMVC_EF.Models;

namespace MVMVC_EF.Controllers
{
    public class PersonAddressController : Controller
    {
        private readonly DBContext _context;

        public PersonAddressController(DBContext context)
        {
            _context = context;
        }

        // GET: PersonAddress
        public async Task<IActionResult> Index()
        {
            var dBContext = _context.PersonAddress
                .Include(p => p.Address)
                .Include(p => p.Person);
            return View(await dBContext.ToListAsync());
        }

        // GET: PersonAddress/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonAddress == null)
            {
                return NotFound();
            }

            var personAddress = await _context.PersonAddress
                .Include(p => p.Address)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personAddress == null)
            {
                return NotFound();
            }

            return View(personAddress);
        }

        // GET: PersonAddress/Create
        public IActionResult Create()
        {
            ViewData["IdAddress"] = new SelectList(_context.Address, "Id", "Name");
            ViewData["IdPerson"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: PersonAddress/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPerson,IdAddress")] PersonAddress personAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAddress"] = new SelectList(_context.Address, "Id", "Name", personAddress.IdAddress);
            ViewData["IdPerson"] = new SelectList(_context.Person, "Id", "FullName", personAddress.IdPerson);
            return View(personAddress);
        }

        // GET: PersonAddress/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonAddress == null)
            {
                return NotFound();
            }

            var personAddress = await _context.PersonAddress.FindAsync(id);
            if (personAddress == null)
            {
                return NotFound();
            }
            ViewData["IdAddress"] = new SelectList(_context.Address, "Id", "Name", personAddress.IdAddress);
            ViewData["IdPerson"] = new SelectList(_context.Person, "Id", "FullName", personAddress.IdPerson);
            return View(personAddress);
        }

        // POST: PersonAddress/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPerson,IdAddress")] PersonAddress personAddress)
        {
            if (id != personAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonAddressExists(personAddress.Id))
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
            ViewData["IdAddress"] = new SelectList(_context.Address, "Id", "Name", personAddress.IdAddress);
            ViewData["IdPerson"] = new SelectList(_context.Person, "Id", "FullName", personAddress.IdPerson);
            return View(personAddress);
        }

        // GET: PersonAddress/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonAddress == null)
            {
                return NotFound();
            }

            var personAddress = await _context.PersonAddress
                .Include(p => p.Address)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personAddress == null)
            {
                return NotFound();
            }

            return View(personAddress);
        }

        // POST: PersonAddress/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonAddress == null)
            {
                return Problem("Entity set 'DBContext.PersonAddress'  is null.");
            }
            var personAddress = await _context.PersonAddress.FindAsync(id);
            if (personAddress != null)
            {
                _context.PersonAddress.Remove(personAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonAddressExists(int id)
        {
          return _context.PersonAddress.Any(e => e.Id == id);
        }
    }
}
