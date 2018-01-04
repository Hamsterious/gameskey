using GamesKey.ViewModels;
using System;
using System.Threading.Tasks;

namespace GamesKey.Services
{
    public interface IPicturesService : IDisposable
    {
        Task<PictureViewModel> FindAsync(int id);
        Task<PictureViewModel> CreateAsync(PictureViewModel viewModel);
    }
}
