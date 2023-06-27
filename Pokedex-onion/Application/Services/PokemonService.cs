using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        //Add

        public async Task Add(SavePokemonViewModel spvm)
        {
            Pokemon pokemon = new();
            pokemon.name = spvm.name;
            pokemon.imageUrl = spvm.imageUrl;
            pokemon.type1 = spvm.type1;
            pokemon.type2 = spvm.type2 == null ? spvm.type1 : spvm.type2;
            pokemon.region = spvm.region;

            await _pokemonRepository.AddAsync(pokemon);
        }

        //Edit

        public async Task Update(SavePokemonViewModel spvm)
        {
            Pokemon pokemon = new();
            pokemon.id = spvm.id;
            pokemon.name = spvm.name;
            pokemon.imageUrl = spvm.imageUrl;
            pokemon.type1 = spvm.type1;
            pokemon.type2 = spvm.type2 == 0 ? spvm.type1 : spvm.type2;
            pokemon.region = spvm.region;

            await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task<SavePokemonViewModel> GetByIdSaveViewModel(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModel spvm = new();
            spvm.id = pokemon.id;
            spvm.name = pokemon.name;
            spvm.imageUrl = pokemon.imageUrl;
            spvm.type1 = pokemon.type1;
            spvm.type2 = pokemon.type2;
            spvm.region = pokemon.region;

            return spvm;

        }

        //Read

        public async Task<List<PokemonViewModel>> GetAllViewModel()
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonViewModel
            {
                id = pokemon.id,
                name = pokemon.name,
                imageUrl = pokemon.imageUrl,
                type1 = pokemon.PokemonType1.name,
                type2 = pokemon.PokemonType2.name == null ? pokemon.PokemonType1.name : pokemon.PokemonType2.name,
                region = pokemon.Region.name,
                Region = pokemon.region

            }).ToList();
        }

        //Filter
        public async Task<List<PokemonViewModel>> GetAllViewModelWithFilters(FilterPokemonViewModel filters)
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();

            var ListViewModels = pokemonList.Select(pokemon => new PokemonViewModel
            {
                id = pokemon.id,
                name = pokemon.name,
                imageUrl = pokemon.imageUrl,
                type1 = pokemon.PokemonType1.name,
                type2 = pokemon.PokemonType2.name == null ? pokemon.PokemonType1.name : pokemon.PokemonType2.name,
                region = pokemon.Region.name,
                Region = pokemon.region

            }).ToList();

            if (filters.Region != null)
            {
                ListViewModels = ListViewModels.Where(pokemon => pokemon.Region == filters.Region.Value).ToList();
            }

            return ListViewModels;
        }

        public async Task<List<PokemonViewModel>> GetAllViewModelWithSearch(string name)
        {
            var pokemonList = await _pokemonRepository.GetAllAsync();

            var ListViewModels = pokemonList.Select(pokemon => new PokemonViewModel
            {
                id = pokemon.id,
                name = pokemon.name,
                imageUrl = pokemon.imageUrl,
                type1 = pokemon.PokemonType1.name,
                type2 = pokemon.PokemonType2.name == null ? pokemon.PokemonType1.name : pokemon.PokemonType2.name,
                region = pokemon.Region.name,
                Region = pokemon.region

            }).ToList();

            if (name != null)
            {
                ListViewModels = ListViewModels.Where(pokemon => pokemon.name == name).ToList();
            }

            return ListViewModels;
        }

        //Delete

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            await _pokemonRepository.DeleteAsync(pokemon);
        }
    }
}
