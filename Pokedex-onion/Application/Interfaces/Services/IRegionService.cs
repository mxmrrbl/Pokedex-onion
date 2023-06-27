using Pokedex.Core.Application.ViewModels;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IRegionService
    {
        Task Add(SaveRegionViewModel srvm);
        Task Delete(int id);
        Task<List<RegionViewModel>> GetAllViewModel();
        Task<SaveRegionViewModel> GetByIdSaveViewModel(int id);
        Task Update(SaveRegionViewModel srvm);
    }
}