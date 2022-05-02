using POC_Backend.Application.Interfaces;
using POC_Backend.Infrastructure.Data.Context;

namespace POC_Backend.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {

        private bool _disposed = false;
        private readonly DBContext _dBContext;

        public UnitOfWork(DBContext rouletteDBContext)
        {
            this._dBContext = rouletteDBContext;
        }

        public async Task Save()
        {
            await this._dBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dBContext.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
