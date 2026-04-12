using _03_Tracking_DataLoad.data;

namespace _03_Tracking_DataLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();
            Seeder.Seed(context);
        }
    }
}
