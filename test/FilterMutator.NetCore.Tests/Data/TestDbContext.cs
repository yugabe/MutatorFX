using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MutatorFX.FluentExtensions;

namespace FilterMutator.NetCore.Tests.Data
{
    public class TestDbContext : DbContext
    {
        public DbSet<Veterinarian> Vets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogOwnership> DogOwnerships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DogsDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veterinarian>().HasMany(v => v.VettedDogs).WithOne(d => d.Vet).HasForeignKey(o => o.VetId);
            modelBuilder.Entity<Owner>().HasMany(o => o.OwnedDogs).WithOne(d => d.Owner).HasForeignKey(o => o.OwnerId);
            modelBuilder.Entity<Dog>().HasMany(d => d.Ownerships).WithOne(o => o.Dog).HasForeignKey(o => o.DogId);

            Enumerable.Range(1, 10).For(i => {
                modelBuilder.Entity<Veterinarian>().HasData(new Veterinarian { Id = i, Name = $"Vet_{i}" });
                modelBuilder.Entity<Owner>().HasData(new Owner { Id = i, Name = $"Owner_{i}" });
                modelBuilder.Entity<Dog>().HasData(new Dog { Id = i, Name = $"Dog_{i}" });
                modelBuilder.Entity<DogOwnership>().HasData(new DogOwnership { DogId = i, OwnerId = i, VetId = i });
            });
        }
    }
}
