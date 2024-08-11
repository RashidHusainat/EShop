using Discount.Grpc.Model;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>()
                .HasData(new List<Coupon>()
                {
                    new Coupon()
                    {
                        Amount=100,
                         Description="Init IPhone Discount",
                         ProductName="Iphone X",
                         Id=1
                    },
                    new Coupon()
                    {
                        Amount=80,
                         Description="Init S10 Discount",
                         ProductName="Samsung Galaxy",
                         Id=2
                    }

                });


            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Coupon> Coupons { get; set; } 
    }
}
