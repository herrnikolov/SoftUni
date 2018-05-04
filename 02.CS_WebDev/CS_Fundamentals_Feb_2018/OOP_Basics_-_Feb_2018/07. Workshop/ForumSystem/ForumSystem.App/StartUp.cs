namespace ForumSystem.App
{
    using Core;
    using Data;
    using DataInitializer;

    public class StartUp
	{
		public static void Main()
		{
            using (var database = new ForumSystemDbContext())
            {
                var initializer = new DbInitializer(database);
                initializer.ResetDatabase();

                // To initialize the database with sample data uncomment the line below:
                //initializer.SeedData();
            }

            Engine engine = new Engine();
			engine.Run();
		}
    }
}
