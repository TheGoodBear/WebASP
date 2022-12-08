using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_EF2.Models;

namespace MVC_EF2.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Project { get; set; } = default!;
        public DbSet<Group> Group { get; set; }
    }
}
