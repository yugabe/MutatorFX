using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MutatorFX.FilterMutator.EFCore
{
    /// <summary>
    /// An <see cref="ISourceAccessor{TEntity}"/>, which provides the given entity type <typeparamref name="TEntity"/> from a <see cref="Microsoft.EntityFrameworkCore.DbContext"/> <typeparamref name="TDbContext"/>.
    /// Uses the context's <see cref="DbContext.Set{TEntity}"/> method to access the queryable datasource.
    /// For single type parameter matching (i.e. when using dependency injection with unbound generics), inherit from this type and constrain the <typeparamref name="TDbContext"/> type. 
    /// Alternatively, you can use the <see cref="DbSetSourceAccessor{TEntity}"/> type which inherits from this type with the base <see cref="Microsoft.EntityFrameworkCore.DbContext"/> implementation as <typeparamref name="TDbContext"/>.
    /// </summary>
    /// <typeparam name="TDbContext">The context used to access the data source.</typeparam>
    /// <typeparam name="TEntity">The entity type which is used to access the context's <see cref="DbSet{TEntity}"/>.</typeparam>
    public class DbSetSourceAccessor<TDbContext, TEntity> : ISourceAccessor<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        /// <summary>
        /// Create an instance of this class with the given context to use when accessing its <typeparamref name="TEntity"/> <see cref="DbSet{TEntity}"/>.
        /// </summary>
        /// <param name="dbContext">The context to use to access the <see cref="DbSet{TEntity}"/>.</param>
        public DbSetSourceAccessor(TDbContext dbContext) => DbContext = dbContext;

        /// <summary>
        /// The source dataset accessor. Uses the <see cref="DbContext"/>'s <see cref="DbContext.Set{TEntity}"/> method for access.
        /// </summary>
        public IQueryable<TEntity> Source => DbContext.Set<TEntity>();

        /// <summary>
        /// The context used to access the datasource queryable.
        /// </summary>
        public TDbContext DbContext { get; }
    }

    /// <summary>
    /// A <see cref="DbSetSourceAccessor{TDbContext, TEntity}"/>, which accepts any <see cref="DbContext"/> as the <see cref="DbSet{TEntity}"/>'s accessor.
    /// </summary>
    /// <typeparam name="TEntity">The entity type used in accessing the <see cref="DbContext"/>'s <see cref="DbContext.Set{TEntity}"/> method.</typeparam>
    public class DbSetSourceAccessor<TEntity> : DbSetSourceAccessor<DbContext, TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Create an instance of this class with the given context to use when accessing its <typeparamref name="TEntity"/> <see cref="DbSet{TEntity}"/>.
        /// </summary>
        /// <param name="dbContext">The context to use to access the <see cref="DbSet{TEntity}"/>.</param>
        public DbSetSourceAccessor(DbContext dbContext) : base(dbContext) { }
    }
}
