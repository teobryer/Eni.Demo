namespace Module6.Tp1.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Module6.Tp1.Web.Business.DataProviders.Abstractions;
    using Module6.Tp1.Web.Business.DataProviders.Dtos;
    using Module6.Tp1.Web.Extensions;
    using Module6.Tp1.Web.Models;

    public class ArmesController : Controller
    {
        private readonly IArmeService armeService;
        private readonly IMapper mapper;

        public ArmesController(IMapper mapper, IArmeService armeService)
        {
            this.mapper = mapper;
            this.armeService = armeService;
        }

        // GET: Armes
        public async Task<IActionResult> Index()
        {
            var armes = await this.armeService.GetAllAsync();

            var armesVM = armes.Select(x => mapper.Map<ArmeViewModel>(x));
            return View(armesVM);
        }

        // GET: Armes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arme = await this.armeService.GetByIdAsync((int)id);
            if (arme == null)
            {
                return NotFound();
            }

            return View(arme.ToVM(mapper));
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
        public async Task<IActionResult> Create([Bind("Id,Nom,Degats")] ArmeViewModel armeVm)
        {
            if (ModelState.IsValid)
            {
                var armeDto = this.mapper.Map<ArmeDto>(armeVm);
                await this.armeService.AddAsync(armeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(armeVm);
        }

        // GET: Armes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arme = await this.armeService.GetByIdAsync((int)id);
            if (arme == null)
            {
                return NotFound();
            }
            return View(arme.ToVM(mapper));
        }

        // POST: Armes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Degats")] ArmeViewModel armeVm)
        {
            if (id != armeVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var armeDto = this.mapper.Map<ArmeDto>(armeVm);
                    await this.armeService.UpdateAsync(id, armeDto);
                }
                catch (Exception)
                {
                    if (!await this.ArmeExists(armeVm.Id))
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
            return View(armeVm);
        }

        // GET: Armes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arme = await this.armeService.GetByIdAsync((int)id);
            if (arme == null)
            {
                return NotFound();
            }

            return View(arme.ToVM(mapper));
        }

        // POST: Armes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.armeService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ArmeExists(int id)
            => await this.armeService.GetByIdAsync(id) is not null;
    }
}
