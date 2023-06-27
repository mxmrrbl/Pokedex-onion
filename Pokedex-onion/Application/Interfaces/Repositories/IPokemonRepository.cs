using Pokedex.Core.Domain.Entities;

namespace Pokedex.Core.Application.Interfaces.Repositories
{
    public interface IPokemonRepository
    {
        Task AddAsync(Pokemon pokemon);
        Task DeleteAsync(Pokemon pokemon);
        Task<List<Pokemon>> GetAllAsync();
        Task<Pokemon> GetByIdAsync(int id);
        Task UpdateAsync(Pokemon pokemon);
    }
}