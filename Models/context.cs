using Microsoft.EntityFrameworkCore;
 
namespace Plate.Models
{
    public class platecontext : DbContext
    {
        public platecontext(DbContextOptions<platecontext> options) : base(options) { }
        public DbSet<Person> Users { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Shopping> Shopping { get; set; }
        public DbSet<Others> Others { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Network> Network { get; set; }
    }
}