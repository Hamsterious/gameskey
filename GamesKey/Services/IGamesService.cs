using GamesKey.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesKey.Services
{
    public interface IGamesService : IDisposable
    {
        IEnumerable<GameViewModel> Find();
        Task<GameViewModel> FindAsync(int gameId);
        Task<GameViewModel> CreateAsync(GameViewModel viewModel);
        Task<GameViewModel> UpdateAsync(int gameId, GameViewModel viewModel);
        Task<GameViewModel> DeleteAsync(int gameId);
    }
}
