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
    public class TypeRepository : ITypeRepository
    {
        private readonly ApplicationContext _dbContext;

        public TypeRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Read all
        public async Task<List<PokemonType>> GetAllAsync()
        {
            return await _dbContext.Set<PokemonType>().ToListAsync();
        }

        //Add
        public async Task AddAsync(PokemonType type)
        {
            await _dbContext.Set<PokemonType>().AddAsync(type);
            await _dbContext.SaveChangesAsync();

        }

        //Read one
        public async Task<PokemonType> GetByIdAsync(int id)
        {
            return await _dbContext.Set<PokemonType>().FindAsync(id);
        }

        //Update
        public async Task UpdateAsync(PokemonType type)
        {
            _dbContext.Entry(type).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        //Delete
        public async Task DeleteAsync(PokemonType type)
        {
            _dbContext.Set<PokemonType>().Remove(type);
            await _dbContext.SaveChangesAsync();
        }
    }
}
