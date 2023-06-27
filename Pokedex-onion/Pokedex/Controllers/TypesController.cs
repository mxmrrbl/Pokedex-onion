using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Infrastructure.Persistence.Contexts;

namespace Pokedex.Controllers
{
    public class TypesController : Controller
    {
        private readonly ITypeService _typeService;

        public TypesController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        //Load
        public async Task<IActionResult> Types()
        {
            return View(await _typeService.GetAllViewModel());
        }

        //Save
        public IActionResult Create()
        {
            return View("SaveType", new SaveTypeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTypeViewModel stvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveType", stvm);
            }

            await _typeService.Add(stvm);
            return RedirectToRoute(new { controller = "Types", action = "Types" });
        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveType", await _typeService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveTypeViewModel stvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", stvm);
            }

            await _typeService.Update(stvm);
            return RedirectToRoute(new { controller = "Types", action = "Types" });
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            return View("DeleteType", await _typeService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _typeService.Delete(id);
            return RedirectToRoute(new { controller = "Types", action = "Types" });
        }
    }
}
