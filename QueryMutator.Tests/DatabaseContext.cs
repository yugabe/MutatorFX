using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueryMutator.Tests
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public DbSet<SmallDog> SmallDogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(Program.ConsoleLoggerFactory)
                .ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning))
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=QMTESTDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Dog>().HasData(new Dog
            {
                Id = 1,
                Name = "Bodri",
                EntityProperty = 5,
                Ignored = "IGNORE!",
                SmallDogId = 1
            });

            modelBuilder.Entity<Dog>().HasData(new Dog
            {   
                Id = 2,
                Name = "Pimpedli",
                EntityProperty = 10,
                SmallDogId = 2
            });

            modelBuilder.Entity<SmallDog>().HasData(new Dog
            {
                Id = 1,
                Name = "Small Bodri"
            });

            modelBuilder.Entity<SmallDog>().HasData(new Dog
            {
                Id = 2,
                Name = "Small Pimpedli"
            });

        }

    }
}
