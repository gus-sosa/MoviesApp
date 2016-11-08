namespace MoviesApp.Models
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(MoviesAppContext context) : base(context)
        {
        }
    }
}