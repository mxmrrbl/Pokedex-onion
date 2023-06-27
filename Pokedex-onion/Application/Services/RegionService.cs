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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        //Add
        public async Task Add(SaveRegionViewModel srvm)
        {
            Region region = new();
            region.name = srvm.name;


            await _regionRepository.AddAsync(region);
        }

        //Read

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var regionList = await _regionRepository.GetAllAsync();
            return regionList.Select(region => new RegionViewModel
            {
                id = region.id,
                name = region.name


            }).ToList();
        }

        //Edit

        public async Task Update(SaveRegionViewModel srvm)
        {
            Region region = new();
            region.id = srvm.id;
            region.name = srvm.name;

            await _regionRepository.UpdateAsync(region);
        }

        public async Task<SaveRegionViewModel> GetByIdSaveViewModel(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            SaveRegionViewModel srvm = new();
            srvm.id = region.id;
            srvm.name = region.name;

            return srvm;
        }

        //Delete

        public async Task Delete(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            await _regionRepository.DeleteAsync(region);
        }
    }
}
