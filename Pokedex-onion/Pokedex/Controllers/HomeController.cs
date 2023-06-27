using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly IRegionService _regionService;

        public HomeController(IPokemonService pokemonService, IRegionService regionService)
        {
            _pokemonService = pokemonService;
            _regionService = regionService;
        }

        public async Task<IActionResult> Index(FilterPokemonViewModel fpvm)
        {
            ViewBag.Regions = await _regionService.GetAllViewModel();
            return View(await _pokemonService.GetAllViewModelWithFilters(fpvm));
        }

        [HttpPost]
        public async Task<IActionResult> Search(string name)
        {
            ViewBag.Regions = await _regionService.GetAllViewModel();
            return View("Index", await _pokemonService.GetAllViewModelWithSearch(name));
        }

       
    }
}