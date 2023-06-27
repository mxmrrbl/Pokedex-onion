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
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationContext _dbContext;

        public PokemonRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Add
        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContext.Set<Pokemon>().AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();

        }

        //Update
        public async Task UpdateAsync(Pokemon pokemon)
        {
            _dbContext.Entry(pokemon).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        //Delete
        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbContext.Set<Pokemon>().Remove(pokemon);
            await _dbContext.SaveChangesAsync();
        }

        //Read all
        public async Task<List<Pokemon>> GetAllAsync()
        {

            return await _dbContext.Pokemons
                .Include(pokemon => pokemon.PokemonType1)
                .Include(pokemon => pokemon.PokemonType2)
                .Include(pokemon => pokemon.Region).ToListAsync();
        }

        //Read one
        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Pokemon>().FindAsync(id);
        }
    }
}
