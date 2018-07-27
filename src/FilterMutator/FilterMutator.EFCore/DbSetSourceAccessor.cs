using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MutatorFX.FilterMutator.EFCore
{
    public class DbSetSourceAccessor<TDbContext, TEntity> : ISourceAccessor<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        public DbSetSourceAccessor(TDbContext dbContext) => DbContext = dbContext;
        public IQueryable<TEntity> Source => DbContext.Set<TEntity>();

        public TDbContext DbContext { get; }
    }

    public class DbSetSourceAccessor<TEntity> : DbSetSourceAccessor<DbContext, TEntity>
        where TEntity : class
    {
        public DbSetSourceAccessor(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
