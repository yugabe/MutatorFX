using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace QueryMutator.Tests
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public DbSet<SmallDog> SmallDogs { get; set; }

        public DbSet<SmallSmallDog> SmallSmallDogs { get; set; }

        public DbSet<NullableEntity> NullableEntities { get; set; }

        public DbSet<Collection> Collections { get; set; }

        public DbSet<CollectionItem> CollectionItems { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(new Dog
            {
                Id = 1,
                Name = "Dog1",
                EntityProperty = 5,
                Ignored = "Ignore this property!",
                SmallDogId = 1
            });

            modelBuilder.Entity<SmallDog>().HasData(new SmallDog
            {
                Id = 1,
                Name = "SmallDog1",
                SmallSmallDogId = 1
            });

            modelBuilder.Entity<SmallSmallDog>().HasData(new SmallDog
            {
                Id = 1,
                Name = "SmallSmallDog1"
            });

            modelBuilder.Entity<NullableEntity>().HasData(new NullableEntity
            {
                Id = 1,
                NullableProperty = null,
                NullablePropertyWithValue = 20,
                NotNullableProperty = 10
            });

            modelBuilder.Entity<Collection>().HasData(new Collection
            {
                Id = 1
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
        }
    }
}
