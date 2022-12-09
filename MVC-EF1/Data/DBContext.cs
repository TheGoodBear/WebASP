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
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_EF1.Models.Project> Project { get; set; } = default!;

        public DbSet<MVC_EF1.Models.Group> Group { get; set; }

        public DbSet<MVC_EF1.Models.Person> Person { get; set; }
    }
}
