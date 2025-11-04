using BulkyWebC_.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebC_
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
           
        }
        public DbSet<Category> Categories { get; set; }
    }
}
