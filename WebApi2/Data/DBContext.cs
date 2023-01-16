using Microsoft.EntityFrameworkCore;
using WebApi2.Models;

namespace WebApi2.Data;

public class DBContext : DbContext
{
    public DBContext (
        DbContextOptions<DBContext> options)
        : base(options)
    {
    }


    public DbSet<Project> Project { get; set; } = default!;

    public DbSet<Group> Group { get; set; }

    public DbSet<Person> Person { get; set; }

    public DbSet<Address> Address { get; set; }

    public DbSet<PersonAddress> PersonAddress { get; set; }

}
