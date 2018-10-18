using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer
{
    /// <summary>
    /// Contains extensions for configuring the <see cref="IWebHost"/> with Kraken modules and services.
    /// </summary>
    public static class WebHostingExtensions
    {
        /// <summary>
        /// Migrate an SQL database using Entity Framework Core migrations with the default <see cref="DbContext"/>.
        /// </summary>
        /// <param name="webHost">The host to execute the startup task on.</param>
        /// <returns>The <paramref name="webHost"/>, after the startup task finished.</returns>
        public static IWebHost MigrateSqlDatabse(this IWebHost webHost)
            => webHost.UseKrakenStartupTask<MigrateSqlDatabase<DbContext>>();

        /// <summary>
        /// Migrate an SQL database using Entity Framework Core migrations with a given <see cref="DbContext"/> type.
        /// </summary>
        /// <typeparam name="T">The type of DbContext to use for migrations.</typeparam>
        /// <param name="webHost">The host to execute the startup task on.</param>
        /// <returns>The <paramref name="webHost"/>, after the startup task finished.</returns>
        public static IWebHost MigrateSqlDatabse<T>(this IWebHost webHost)
            where T : DbContext
            => webHost.UseKrakenStartupTask<MigrateSqlDatabase<T>>();
    }
}
