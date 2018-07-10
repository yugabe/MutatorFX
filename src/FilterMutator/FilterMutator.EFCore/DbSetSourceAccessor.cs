using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MutatorFX.FilterMutator.EFCore
{
    public sealed class DbSetSourceAccessor<TDbContext, TEntity> : ISourceAccessor<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        public DbSetSourceAccessor(TDbContext dbContext) => DbContext = dbContext;
        public IQueryable<TEntity> Source => DbContext.Set<TEntity>();

        public TDbContext DbContext { get; }
    }
}
