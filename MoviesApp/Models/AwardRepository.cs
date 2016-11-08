using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class AwardRepository : GenericRepository<Award>, IAwardRepository
    {
        public AwardRepository(MoviesAppContext context) : base(context)
        {
        }
    }
}