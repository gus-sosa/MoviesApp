﻿namespace MoviesApp.Models
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesAppContext context) : base(context)
        {
        }
    }
}