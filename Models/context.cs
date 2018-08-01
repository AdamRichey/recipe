using Microsoft.EntityFrameworkCore;
 
namespace Portfolio.Models
{
    public class portfoliocontext : DbContext
    {
        public portfoliocontext(DbContextOptions<portfoliocontext> options) : base(options) { }
   
    }

    
}