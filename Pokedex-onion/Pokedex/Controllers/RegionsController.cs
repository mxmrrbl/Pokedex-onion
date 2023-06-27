using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Infrastructure.Persistence.Contexts;

namespace Pokedex.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        //Load
        public async Task<IActionResult> Regions()
        {
            return View(await _regionService.GetAllViewModel());
        }

        //Save
        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModel srvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", srvm);
            }

            await _regionService.Add(srvm);
            return RedirectToRoute(new { controller = "Regions", action = "Regions" });
        }

        //Edit

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveRegion", await _regionService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModel srvm)
        {
            if (!ModelState.IsValid)
            {

                return View("SaveRegion", srvm);
            }

            await _regionService.Update(srvm);
            return RedirectToRoute(new { controller = "Regions", action = "Regions" });
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            return View("DeleteRegion", await _regionService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _regionService.Delete(id);
            return RedirectToRoute(new { controller = "Regions", action = "Regions" });
        }

    }
}
