using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MutatorFX.Coding;

namespace FilterMutator.NetCore.Tests.Data
{
    public class TestDbContext : DbContext
    {
        private static readonly object _syncRoot = new object();
        private static bool Initialized;

        public TestDbContext()
        {
            if (!Initialized)
                lock (_syncRoot)
                    if (!Initialized)
                    {
                        Database.EnsureCreated();
                        Initialized = true;
                    }
        }

        public DbSet<Veterinarian> Vets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogOwnership> DogOwnerships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseInMemoryDatabase("DogsDB");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veterinarian>().HasMany(v => v.VettedDogs).WithOne(d => d.Vet).HasForeignKey(o => o.VetId);
            modelBuilder.Entity<Owner>().HasMany(o => o.OwnedDogs).WithOne(d => d.Owner).HasForeignKey(o => o.OwnerId);
            modelBuilder.Entity<Dog>().HasMany(d => d.Ownerships).WithOne(o => o.Dog).HasForeignKey(o => o.DogId);

            Enumerable.Range(1, 20).For(i =>
            {
                modelBuilder.Entity<Veterinarian>().HasData(new Veterinarian { Id = i, Name = $"Vet_{i}" });
                modelBuilder.Entity<Owner>().HasData(new Owner { Id = i, Name = $"Owner_{i}" });
                modelBuilder.Entity<Dog>().HasData(new Dog { Id = i, Name = $"Dog_{i}", ParentId = i % 3 == 0 ? i - 2 : default });
                modelBuilder.Entity<DogOwnership>().HasData(
                    new DogOwnership { Id = i * 2, DogId = i, OwnerId = i, VetId = i },
                    new DogOwnership { Id = i * 2 - 1, DogId = i % 2, OwnerId = i * 2, VetId = i });
            });
        }
    }
}
