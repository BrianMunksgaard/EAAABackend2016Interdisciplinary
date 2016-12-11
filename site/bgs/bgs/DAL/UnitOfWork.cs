using System;

namespace bgs.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly BgsContext _context;

        private bool disposed = false;

        // Properties for Repositories

        public UnitOfWork()
        {
            _context = new BgsContext();
        }

        public UnitOfWork(BgsContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}