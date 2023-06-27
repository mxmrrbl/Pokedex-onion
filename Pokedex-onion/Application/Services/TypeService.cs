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
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        //Add
        public async Task Add(SaveTypeViewModel trvm)
        {
            PokemonType type = new();
            type.name = trvm.name;


            await _typeRepository.AddAsync(type);
        }

        //Read

        public async Task<List<TypeViewModel>> GetAllViewModel()
        {
            var typeList = await _typeRepository.GetAllAsync();
            return typeList.Select(type => new TypeViewModel
            {
                id = type.id,
                name = type.name


            }).ToList();
        }

        //Edit

        public async Task Update(SaveTypeViewModel stvm)
        {
            PokemonType type = new();
            type.id = stvm.id;
            type.name = stvm.name;

            await _typeRepository.UpdateAsync(type);
        }

        public async Task<SaveTypeViewModel> GetByIdSaveViewModel(int id)
        {
            var type = await _typeRepository.GetByIdAsync(id);

            SaveTypeViewModel stvm = new();
            stvm.id = type.id;
            stvm.name = type.name;

            return stvm;
        }

        //Delete

        public async Task Delete(int id)
        {
            var region = await _typeRepository.GetByIdAsync(id);
            await _typeRepository.DeleteAsync(region);
        }
    }
}
