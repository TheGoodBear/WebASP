using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVMVC_EF.Models;

namespace MVMVC_EF.Data
{
    public class DBContext : DbContext
    {
        public DBContext (
            DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(
            ModelBuilder builder)
        {
            builder.Entity<Person>()
                .HasIndex(p => p.Email)
                .IsUnique();

            builder.Entity<Group>()
                .HasIndex(p => p.Number)
                .IsUnique();
        }


        public DbSet<Project> Project { get; set; } = default!;

        public DbSet<Group> Group { get; set; }

        public DbSet<Person> Person { get; set; }

    }
}
