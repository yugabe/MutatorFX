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

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
    }
}
