using DIO.Marvel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DIO.Marvel.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Hero> heroes { get; set; }
        public DbSet<Group> groups { get; set; }
    }
}