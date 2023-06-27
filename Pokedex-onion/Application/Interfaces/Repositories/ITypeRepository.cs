using Pokedex.Core.Domain.Entities;

namespace Pokedex.Core.Application.Interfaces.Repositories
{
    public interface ITypeRepository
    {
        Task AddAsync(PokemonType type);
        Task DeleteAsync(PokemonType type);
        Task<List<PokemonType>> GetAllAsync();
        Task<PokemonType> GetByIdAsync(int id);
        Task UpdateAsync(PokemonType type);
    }
}