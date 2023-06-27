using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Repositores
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationContext _dbContext;

        public RegionRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Read all
        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Set<Region>().ToListAsync();
        }

        //Add
        public async Task AddAsync(Region region)
        {
            await _dbContext.Set<Region>().AddAsync(region);
            await _dbContext.SaveChangesAsync();

        }

        //Read one
        public async Task<Region> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Region>().FindAsync(id);
        }

        //Update
        public async Task UpdateAsync(Region region)
        {
            _dbContext.Entry(region).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        //Delete
        public async Task DeleteAsync(Region region)
        {
            _dbContext.Set<Region>().Remove(region);
            await _dbContext.SaveChangesAsync();
        }


    }
}
