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
        private GenericRepository<Movie> movieRepository;
        private GenericRepository<Director> directorRepository;
        private GenericRepository<Award> awardRepository;
        private GenericRepository<AwardDirector> awardDirectorRepository;

        public GenericRepository<Movie> MoviesRespository
        {
            get
            {

                if (this.movieRepository == null)
                {
                    this.movieRepository = new GenericRepository<Movie>(context);
                }
                return movieRepository;
            }
        }

        public GenericRepository<Director> DirectorRepository
        {
            get
            {
                if (directorRepository == null)
                    directorRepository = new GenericRepository<Director>(context);
                return directorRepository;
            }
        }

        public GenericRepository<Award> AwardRepository
        {
            get
            {
                if (awardRepository == null)
                    awardRepository = new GenericRepository<Award>(context);
                return awardRepository;
            }
        }

        public GenericRepository<AwardDirector> AwardDirectorRepository
        {
            get
            {
                if (awardDirectorRepository == null)
                    awardDirectorRepository = new GenericRepository<AwardDirector>(context);
                return awardDirectorRepository;
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