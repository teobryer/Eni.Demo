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
    public class SamouraisController : Controller
    {
        private readonly AccesLayer<Samourai> samouraiDAL;

        public SamouraisController(AccesLayer<Samourai> Samourai)
        {
            samouraiDAL = Samourai;
        }

        // GET: Samourai
        public async Task<IActionResult> Index()
        {

            var Samourai = await samouraiDAL.recupererTous();
            return View(Samourai);
        }

        // GET: Samourai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Samourai = samouraiDAL.recupererTous().Result
                .FirstOrDefault(m => m.Id == id);
            if (Samourai == null)
            {
                return NotFound();
            }

            return View(Samourai);
        }

        // GET: Samourai/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Samourai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Force")] Samourai Samourai)
        {
            if (ModelState.IsValid)
            {
                await samouraiDAL.ajouter(Samourai);
                return RedirectToAction(nameof(Index));
            }
            return View(Samourai);
        }

        // GET: Samourai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Samourai = await samouraiDAL.recupererParId((int)id);
            if (Samourai == null)
            {
                return NotFound();
            }
            return View(Samourai);
        }

        // POST: Samourai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Force")] Samourai Samourai)
        {
            if (id != Samourai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await samouraiDAL.modifier(id, Samourai);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamouraiExists(Samourai.Id))
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
            return View(Samourai);
        }

        // GET: Samourai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var Samourai = await samouraiDAL.recupererParId((int)id);
            if (Samourai == null)
            {
                return NotFound();
            }

            return View(Samourai);
        }

        // POST: Samourai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await samouraiDAL.supprimer(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SamouraiExists(int id)
        {
            return samouraiDAL.Exists(id);
        }
    }
}
