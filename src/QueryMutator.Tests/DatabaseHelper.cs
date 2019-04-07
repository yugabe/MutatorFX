using Microsoft.EntityFrameworkCore;

namespace QueryMutator.Tests
{
    public static class DatabaseHelper
    {
        private static DbContextOptions<DatabaseContext> Options { get; set; } = null;

        public static DbContextOptions<DatabaseContext> GetDatabaseOptions(string databaseName)
        {
            // Since there are no add/update/delete operation in the tests, create the database only once
            if(Options is null)
            {
                Options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseInMemoryDatabase(databaseName)
                    .Options;

                using (var context = new DatabaseContext(Options))
                {
                    context.Database.EnsureCreated(); // This call is necessary for the data seeding to work
                }
            }

            return Options;
        }
    }
}
