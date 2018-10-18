using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MutatorFX.Coding;
using MutatorFX.Kraken.AspNetCore;
using System.Threading.Tasks;

namespace MutatorFX.Kraken.AspNetCore.EntityFrameworkCore.SqlServer
{
    public class MigrateSqlDatabase<TDbContext> : IKrakenStartupTask
        where TDbContext : DbContext
    {
        public MigrateSqlDatabase(TDbContext dbContext) => DbContext = dbContext;

        public TDbContext DbContext { get; }

        public Task OnBeforeHostStartsAsync(IWebHost webHost)
            => Task.CompletedTask.Do(_ => DbContext.Database.Migrate());
    }
}
