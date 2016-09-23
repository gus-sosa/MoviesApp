using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MoviesApp.Models
{
    public class UnitOfWork : IDisposable
    {
        private MoviesAppContext context = new MoviesAppContext();
        private GenericRepository<Movie> departmentRepository;

        public GenericRepository<Movie> MoviesRespository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Movie>(context);
                }
                return departmentRepository;
            }
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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