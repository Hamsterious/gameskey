using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamesKey.ViewModels;
using System.Linq;
using GamesKey.Data;
using Microsoft.EntityFrameworkCore;

namespace GamesKey.Services
{
    public class GamesService : IGamesService
    {
        private readonly GamesKeyDbContext _context;

        public GamesService(GamesKeyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<GameViewModel> Find()
        {
            return _context.Games.Select(g => new GameViewModel(g));
        }

        public async Task<GameViewModel> FindAsync(int gameId)
        {
            var game = await _context.Games.FindAsync(gameId);

            await _context.Entry(game).Reference(g => g.Developer).LoadAsync();
            await _context.Entry(game).Reference(g => g.Publisher).LoadAsync();
            await _context.Entry(game).Reference(g => g.Picture).LoadAsync();
            await _context.Entry(game).Collection(g => g.GameGenres).LoadAsync();
            await _context.Entry(game).Collection(g => g.GameTags).LoadAsync();

            return new GameViewModel(game)
            {
                Developer = game.Developer?.Name,
                Publisher = game.Publisher?.Name,
                Genres = _context.Genres.Where(g => game.GameGenres.Any(gg => gg.GenreId == g.Id)).Select(g => g.Name).ToArray(),
                Tags = _context.Tags.Where(t => game.GameTags.Any(gt => gt.TagId == t.Id)).Select(t => t.Name).ToArray()
            };
        }

        public async Task<GameViewModel> CreateAsync(GameViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.Developer))
            {
                var developer = await _context.Developers.SingleOrDefaultAsync(d => d.Name == viewModel.Developer);
                if (developer == null) viewModel.Model.Developer = new Developer { Name = viewModel.Developer };
                else viewModel.Model.DeveloperId = developer.Id;
            }

            if (!string.IsNullOrEmpty(viewModel.Publisher))
            {
                var publisher = await _context.Publishers.SingleOrDefaultAsync(d => d.Name == viewModel.Publisher);
                if (publisher == null) viewModel.Model.Publisher = new Publisher { Name = viewModel.Publisher };
                else viewModel.Model.DeveloperId = publisher.Id;
            }

            if (viewModel.Genres != null)
            {
                foreach (var genre in await _context.Genres.Where(g => viewModel.Genres.Contains(g.Name)).ToListAsync())
                {
                    viewModel.Model.GameGenres.Add(new GameGenre { Game = viewModel.Model, GenreId = genre.Id });
                }
                foreach (var genre in viewModel.Genres.Where(g => _context.Genres.All(x => x.Name != g)))
                {
                    viewModel.Model.GameGenres.Add(new GameGenre { Game = viewModel.Model, Genre = new Genre { Name = genre } });
                }
            }

            if (viewModel.Tags != null)
            {
                foreach (var tag in await _context.Tags.Where(g => viewModel.Tags.Contains(g.Name)).ToListAsync())
                {
                    viewModel.Model.GameTags.Add(new GameTag { Game = viewModel.Model, TagId = tag.Id });
                }
                foreach (var tag in viewModel.Tags.Where(t => _context.Tags.All(x => x.Name != t)))
                {
                    viewModel.Model.GameTags.Add(new GameTag { Game = viewModel.Model, Tag = new Tag { Name = tag } });
                }
            }

            _context.Games.Add(viewModel.Model);

            await _context.SaveChangesAsync();
            return viewModel;
        }

        public Task<GameViewModel> UpdateAsync(int id, GameViewModel viewModel) => throw new NotImplementedException();

        public Task<GameViewModel> DeleteAsync(int id) => throw new NotImplementedException();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GamesService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
