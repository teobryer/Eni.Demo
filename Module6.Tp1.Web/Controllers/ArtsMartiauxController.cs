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

    public class ArtsMartiauxController : Controller
    {
        private readonly IArtMartialService ArtMartialService;
        private readonly IMapper mapper;

        public ArtsMartiauxController(IMapper mapper, IArtMartialService ArtMartialService)
        {
            this.mapper = mapper;
            this.ArtMartialService = ArtMartialService;
        }

        // GET: ArtMartials
        public async Task<IActionResult> Index()
        {
            var ArtMartials = await this.ArtMartialService.GetAllAsync();

            var ArtMartialsVM = ArtMartials.Select(x => mapper.Map<ArtMartialViewModel>(x));
            return View(ArtMartialsVM);
        }

        // GET: ArtMartials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ArtMartial = await this.ArtMartialService.GetByIdAsync((int)id);
            if (ArtMartial == null)
            {
                return NotFound();
            }

            return View(ArtMartial.ToVM(mapper));
        }

        // GET: ArtMartials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtMartials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtMartialViewModel ArtMartialVm)
        {
            if (ModelState.IsValid)
            {
                var ArtMartialDto = this.mapper.Map<ArtMartialDto>(ArtMartialVm);
                await this.ArtMartialService.AddAsync(ArtMartialDto);
                return RedirectToAction(nameof(Index));
            }
            return View(ArtMartialVm);
        }

        // GET: ArtMartials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ArtMartial = await this.ArtMartialService.GetByIdAsync((int)id);
            if (ArtMartial == null)
            {
                return NotFound();
            }
            return View(ArtMartial.ToVM(mapper));
        }

        // POST: ArtMartials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  ArtMartialViewModel ArtMartialVm)
        {
            if (id != ArtMartialVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ArtMartialDto = this.mapper.Map<ArtMartialDto>(ArtMartialVm);
                    await this.ArtMartialService.UpdateAsync(id, ArtMartialDto);
                }
                catch (Exception)
                {
                    if (!await this.ArtMartialExists(ArtMartialVm.Id))
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
            return View(ArtMartialVm);
        }

        // GET: ArtMartials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ArtMartial = await this.ArtMartialService.GetByIdAsync((int)id);
            if (ArtMartial == null)
            {
                return NotFound();
            }

            return View(ArtMartial.ToVM(mapper));
        }

        // POST: ArtMartials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.ArtMartialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ArtMartialExists(int id)
            => await this.ArtMartialService.GetByIdAsync(id) is not null;
    }
}
