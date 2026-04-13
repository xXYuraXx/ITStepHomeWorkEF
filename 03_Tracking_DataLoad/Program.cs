using _03_Tracking_DataLoad.data;

namespace _03_Tracking_DataLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();
            Seeder.Seed(context);

                var gameRepo = new Repositories.GameRepository(context);
                var genreRepo = new Repositories.GenreRepository(context);
                var publisherRepo = new Repositories.PublisherRepository(context);
    
                var ge1 = genreRepo.GetGamesByGenreAsync(1).Result;
                Console.WriteLine($"Games of Genre 1: {string.Join(", ", ge1.Select(g => g.Name))}");

                var ge2 = gameRepo.GetGenresByGameAsync(2).Result;
                Console.WriteLine($"Genres of Game 2: {string.Join(", ", ge2.Select(g => g.Name))}");
    
                var g1 = publisherRepo.GetGamesByPublisherAsync(1).Result;
                Console.WriteLine($"Games of Publisher 1: {string.Join(", ", g1.Select(g => g.Name))}");
        }
    }
}
