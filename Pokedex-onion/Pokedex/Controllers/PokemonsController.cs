using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Infrastructure.Persistence.Contexts;

namespace Pokedex.Controllers
{
    public class PokemonsController : Controller
    {
        private readonly IPokemonService _pokemonService;

        private readonly ITypeService _typeService;

        private readonly IRegionService _regionService;

        public PokemonsController(IPokemonService pokemonService, ITypeService typeService, IRegionService regionService)
        {
            _pokemonService = pokemonService;
            _typeService = typeService;
            _regionService = regionService;
        }

        //Load

        public async Task<IActionResult> Pokemons()
        {
            return View(await _pokemonService.GetAllViewModel());
        }

        //Save

        public async Task<IActionResult> Create()
        {
            ViewBag.regions = new SelectList(await _regionService.GetAllViewModel(),"id","name");
            ViewBag.types = new SelectList(await _typeService.GetAllViewModel(), "id", "name");

            return View("SavePokemon", new SavePokemonViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModel spvm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.regions = new SelectList(await _regionService.GetAllViewModel(), "id", "name");
                ViewBag.types = new SelectList(await _typeService.GetAllViewModel(), "id", "name");

                return View("SavePokemon", spvm);
            }

            await _pokemonService.Add(spvm);
            return RedirectToRoute(new {controller = "Pokemons", action = "Pokemons"});
        }

        //Edit

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.regions = new SelectList(await _regionService.GetAllViewModel(), "id", "name");
            ViewBag.types = new SelectList(await _typeService.GetAllViewModel(), "id", "name");

            return View("SavePokemon",await _pokemonService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModel spvm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.regions = new SelectList(await _regionService.GetAllViewModel(), "id", "name");
                ViewBag.types = new SelectList(await _typeService.GetAllViewModel(), "id", "name");

                return View("SavePokemon", spvm);
            }

            await _pokemonService.Update(spvm);
            return RedirectToRoute(new { controller = "Pokemons", action = "Pokemons" });
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            return View("DeletePokemon", await _pokemonService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller = "Pokemons", action = "Pokemons" });
        }
    }
}
