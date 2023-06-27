using Pokedex.Core.Domain.Entities;

namespace Pokedex.Core.Application.Interfaces.Repositories
{
    public interface IRegionRepository
    {
        Task AddAsync(Region region);
        Task DeleteAsync(Region region);
        Task<List<Region>> GetAllAsync();
        Task<Region> GetByIdAsync(int id);
        Task UpdateAsync(Region region);
    }
}