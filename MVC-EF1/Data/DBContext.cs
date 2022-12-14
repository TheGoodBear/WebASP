using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_EF1.Models;

namespace MVC_EF1.Data
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
