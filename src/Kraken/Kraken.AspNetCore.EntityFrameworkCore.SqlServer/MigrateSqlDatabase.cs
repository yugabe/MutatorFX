using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MutatorFX.Coding;
using System.Threading.Tasks;

namespace MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer
{
    /// <summary>
    /// A startup task that calls <see cref="RelationalDatabaseFacadeExtensions.Migrate"/> on a <typeparamref name="TDbContext"/> instance.
    /// </summary>
    /// <typeparam name="TDbContext">The type of the <see cref="Microsoft.EntityFrameworkCore.DbContext"/> to use.</typeparam>
    public class MigrateSqlDatabase<TDbContext> : IKrakenStartupTask
        where TDbContext : DbContext
    {
        /// <summary>
        /// Create a new task that can migrate the database.
        /// </summary>
        /// <param name="dbContext">The instance of <typeparamref name="TDbContext"/> to use for applying migrations.</param>
        public MigrateSqlDatabase(TDbContext dbContext) => DbContext = dbContext;

        /// <summary>
        /// The instance of <typeparamref name="TDbContext"/> to use for applying migrations.
        /// </summary>
        public TDbContext DbContext { get; }

        /// <summary>
        /// Applies all migrations to the database.
        /// </summary>
        /// <param name="webHost">The host to use for migrations.</param>
        /// <returns>A completed task.</returns>
        public Task OnBeforeHostStartsAsync(IWebHost webHost)
            => Task.CompletedTask.Do(DbContext.Database.Migrate);
    }
}
