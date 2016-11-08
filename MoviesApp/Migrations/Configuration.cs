namespace MoviesApp.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesApp.Models.MoviesAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MoviesApp.Models.MoviesAppContext";
        }

        protected override void Seed(MoviesApp.Models.MoviesAppContext context)
        {
        }
    }
}
