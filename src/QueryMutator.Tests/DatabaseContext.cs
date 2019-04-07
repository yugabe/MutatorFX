using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace QueryMutator.Tests
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ParentEntity> ParentEntities { get; set; }

        public DbSet<NestedEntity> NestedEntities { get; set; }

        public DbSet<NestedNestedEntity> NestedNestedEntities { get; set; }

        public DbSet<NullableEntity> NullableEntities { get; set; }

        public DbSet<NullableParentEntity> NullableParentEntities { get; set; }

        public DbSet<NestedNullableEntity> NestedNullableEntities { get; set; }

        public DbSet<CollectionParent> CollectionParents { get; set; }

        public DbSet<Collection> Collections { get; set; }

        public DbSet<CollectionItem> CollectionItems { get; set; }

        public DbSet<DependentNestedCollectionParent> DependentNestedCollectionParents { get; set; }

        public DbSet<DependentNestedCollection> DependentNestedCollections { get; set; }

        public DbSet<DependentNestedCollectionItem> DependentNestedCollectionItems { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentEntity>().HasData(new ParentEntity
            {
                Id = 1,
                Name = "Entity1",
                EntityProperty = 5,
                Ignored = "Ignore this property!",
                NestedEntityId = 1
            });

            modelBuilder.Entity<NestedEntity>().HasData(new NestedEntity
            {
                Id = 1,
                Name ="NestedEntity1",
                NestedNestedEntityId = 1
            });

            modelBuilder.Entity<NestedNestedEntity>().HasData(new NestedEntity
            {
                Id = 1,
                Name = "NestedNestedEntity1"
            });

            modelBuilder.Entity<NullableEntity>().HasData(new NullableEntity
            {
                Id = 1,
                NullableProperty = null,
                NullablePropertyWithValue = 20,
                NotNullableProperty = 10
            });
            
            modelBuilder.Entity<NestedNullableEntity>().HasData(new NestedNullableEntity
            {
                Id = 1,
                NotNullableToNullable = 10,
                NullableToNullable = null,
                NullableToNotNullable = null,
                NullableWithValueToNotNullable = 20
            });

            modelBuilder.Entity<NullableParentEntity>().HasData(new NullableParentEntity
            {
                Id = 1,
                NestedNullableEntityId = 1
            });

            modelBuilder.Entity<CollectionParent>().HasData(new CollectionParent
            {
                Id = 1
            });

            modelBuilder.Entity<Collection>().HasData(new Collection
            {
                Id = 1,
                CollectionParentId = 1,
            });

            modelBuilder.Entity<Collection>().HasData(new Collection
            {
                Id = 2,
                CollectionParentId = 1,
            });

            modelBuilder.Entity<CollectionItem>().HasData(new CollectionItem
            {
                Id = 1,
                CollectionId = 1,
            });

            modelBuilder.Entity<CollectionItem>().HasData(new CollectionItem
            {
                Id = 2,
                CollectionId = 1,
            });

            modelBuilder.Entity<DependentNestedCollection>().HasData(new DependentNestedCollection
            {
                Id = 1,
            });

            modelBuilder.Entity<DependentNestedCollectionParent>().HasData(new DependentNestedCollectionParent
            {
                Id = 1,
                DependentNestedCollectionId = 1
            });

            modelBuilder.Entity<DependentNestedCollectionItem>().HasData(new DependentNestedCollectionItem
            {
                Id = 1,
                DependentNestedCollectionId = 1,
            });

            modelBuilder.Entity<DependentNestedCollectionItem>().HasData(new DependentNestedCollectionItem
            {
                Id = 2,
                DependentNestedCollectionId = 1,
            });
        }
    }
}
