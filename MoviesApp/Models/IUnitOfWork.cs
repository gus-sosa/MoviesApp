﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository MovieRepository { get; }

        IDirectorRepository DirectorRepository { get; }

        IAwardRepository AwardRepository { get; }

        Task<int> Save();
    }
}