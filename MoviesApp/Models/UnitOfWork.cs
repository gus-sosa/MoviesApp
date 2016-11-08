﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MoviesApp.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private MoviesAppContext context;

        public UnitOfWork(IMovieRepository movieRepository, IDirectorRepository directorRepository, IAwardRepository awardRepository, MoviesAppContext context)
        {
            MovieRepository = movieRepository;
            DirectorRepository = directorRepository;
            AwardRepository = awardRepository;

            this.context = context;
        }

        public IMovieRepository MovieRepository { get; private set; }

        public IDirectorRepository DirectorRepository { get; private set; }

        public IAwardRepository AwardRepository { get; private set; }

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