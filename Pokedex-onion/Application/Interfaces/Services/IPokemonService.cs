using Pokedex.Core.Application.ViewModels;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IPokemonService
    {
        Task Add(SavePokemonViewModel spvm);
        Task Delete(int id);
        Task<List<PokemonViewModel>> GetAllViewModel();
        Task<List<PokemonViewModel>> GetAllViewModelWithFilters(FilterPokemonViewModel filters);
        Task<List<PokemonViewModel>> GetAllViewModelWithSearch(string name);
        Task<SavePokemonViewModel> GetByIdSaveViewModel(int id);
        Task Update(SavePokemonViewModel spvm);
    }
}