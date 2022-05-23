namespace Module6.Tp1.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Module6.Tp1.Web.Business.DataProviders.Abstractions;
    using Module6.Tp1.Web.Business.DataProviders.Dtos;
    using Module6.Tp1.Web.Extensions;
    using Module6.Tp1.Web.Models;

    public class SamouraisController : Controller
    {
        private readonly ISamouraiService samouraiService;
        private readonly IArmeService armeService;
        private readonly IMapper mapper;

        public SamouraisController(IMapper mapper, ISamouraiService samouraiService, IArmeService armeService)
        {
            this.mapper = mapper;
            this.samouraiService = samouraiService;
            this.armeService = armeService;
        }

        private async Task InitListesViewData()
        {

            ViewData["armes"] = (await armeService.GetAllAsync()).Select(x=> x.ToVM(mapper)).ToList();
        
        }


        // GET: Samourais
        public async Task<IActionResult> Index()
        {
            var collection = await this.samouraiService.GetAllAsync();
            return View(this.mapper.Map<List<SamouraiViewModel>>(collection));
        }

        // GET: Samourais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samourai = await this.samouraiService.GetByIdAsync((int)id);
            if (samourai == null)
            {
                return NotFound();
            }

            return View(samourai.ToVM(mapper));
        }

        // GET: Samourais/Create
        public async Task<IActionResult> Create()
        {

            await InitListesViewData();
            return View();
        }

        // POST: Samourais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SamouraiViewModel samouraiVm)
        {
            if (ModelState.IsValid)
            {
                var samouraiDto = this.mapper.Map<SamouraiDto>(samouraiVm);
                await this.samouraiService.AddAsync(samouraiDto);
                return RedirectToAction(nameof(Index));
            }
            return View(samouraiVm);
        }

        // GET: Samourais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samourai = await this.samouraiService.GetByIdAsync((int)id);

            
            if (samourai == null)
            {
                return NotFound();
            }

           await  InitListesViewData();
            return View(samourai.ToVM(this.mapper));
        }

        // POST: Samourais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  SamouraiViewModel samouraiVm)
        {
            if (id != samouraiVm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var samouraiDto = this.mapper.Map<SamouraiDto>(samouraiVm);
                    await this.samouraiService.UpdateAsync(id, samouraiDto);
                }
                catch (Exception)
                {
                    if (!await this.SamouraiExists(samouraiVm.Id))
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
            return View(samouraiVm);
        }

        // GET: Samourais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samourai = await this.samouraiService.GetByIdAsync((int)id);
            if (samourai == null)
            {
                return NotFound();
            }

            return View(samourai.ToVM(mapper));
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.samouraiService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SamouraiExists(int id)
            => await this.samouraiService.GetByIdAsync(id) is not null;
    }
}
