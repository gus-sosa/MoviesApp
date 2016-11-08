namespace MoviesApp.Models
{
    public class AwardRepository : GenericRepository<Award>, IAwardRepository
    {
        public AwardRepository(MoviesAppContext context) : base(context)
        {
        }
    }
}