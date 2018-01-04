using GamesKey.ViewModels;
using System.Threading.Tasks;

namespace GamesKey.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly GamesKeyDbContext _context;

        public PicturesService(GamesKeyDbContext context)
        {
            _context = context;
        }

        public async Task<PictureViewModel> FindAsync(int id)
        {
            return new PictureViewModel(await _context.Pictures.FindAsync(id));
        }

        public async Task<PictureViewModel> CreateAsync(PictureViewModel viewModel)
        {
            _context.Add(viewModel.Model);
            await _context.SaveChangesAsync();
            return viewModel;
        }

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
        // ~PictureService() {
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
