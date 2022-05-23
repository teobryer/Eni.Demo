using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tp_Samourai.DAL;
using Tp_Samourai.DAL.Entities;

namespace Tp_Samourai.Web.Controllers
{
    public class ArmesController : Controller
    {
        private readonly ArmeAccessLayer armesDAL;

        public ArmesController(ArmeAccessLayer armes)
        {
            armesDAL = armes;
        }

        // GET: Armes
        public async Task<IActionResult> Index()
        {
            return View(armesDAL.GetArmesAsync());
        }

        // GET: Armes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arme = armesDAL.GetArmesAsync().Result
                .FirstOrDefault(m => m.Id == id);
            if (arme == null)
            {
                return NotFound();
            }

            return View(arme);
        }

        // GET: Armes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Armes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Degats")] Arme arme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arme);
        }

        // GET: Armes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arme = await _context.Armes.FindAsync(id);
            if (arme == null)
            {
                return NotFound();
            }
            return View(arme);
        }

        // POST: Armes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Degats")] Arme arme)
        {
            if (id != arme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmeExists(arme.Id))
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
            return View(arme);
        }

        // GET: Armes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arme = await _context.Armes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arme == null)
            {
                return NotFound();
            }

            return View(arme);
        }

        // POST: Armes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arme = await _context.Armes.FindAsync(id);
            _context.Armes.Remove(arme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmeExists(int id)
        {
            return _context.Armes.Any(e => e.Id == id);
        }
    }
}
