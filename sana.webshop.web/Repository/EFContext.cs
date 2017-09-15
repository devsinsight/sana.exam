using Microsoft.EntityFrameworkCore;
using sana.webshop.web.Domain;

namespace sana.webshop.web.Repository
{
    public class EFContext : DbContext
    {
        public DbSet<Product> Products { get; set; }


        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
