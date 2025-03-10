using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    public class Startup
    {
        static void Main(string[] args)
        {
			try
			{
				using StudentSystemContext dbContext
					= new StudentSystemContext();

				dbContext.Database.EnsureDeleted();
				dbContext.Database.EnsureCreated();

			}
			catch (Exception e)
			{
                Console.WriteLine(e.Message);

            }
        }
    }
}
