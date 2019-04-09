using Microsoft.EntityFrameworkCore;

namespace QueryMutator.Tests
{
    public static class DatabaseHelper
    {
        public static DbContextOptions<DatabaseContext> Options { get; set; } = null;
        
        public static void CreateDatabase(string databaseName)
        {
            Options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            using (var context = new DatabaseContext(Options))
            {
                context.Database.EnsureCreated(); // This call is necessary for the data seeding to work
            }
        }
    }
}
