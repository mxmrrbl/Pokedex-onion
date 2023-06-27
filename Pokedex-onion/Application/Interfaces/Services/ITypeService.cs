using Pokedex.Core.Application.ViewModels;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface ITypeService
    {
        Task Add(SaveTypeViewModel trvm);
        Task Delete(int id);
        Task<List<TypeViewModel>> GetAllViewModel();
        Task<SaveTypeViewModel> GetByIdSaveViewModel(int id);
        Task Update(SaveTypeViewModel stvm);
    }
}