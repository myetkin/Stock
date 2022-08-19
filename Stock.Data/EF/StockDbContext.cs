using Stock.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;


namespace Stock.Data.EF
{
    public partial class StockDbContext : DbContext
    {
        public StockDbContext() 
        {
        }

        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {
        }

        public DbSet<tb_Product> tb_Product { get; set; }
        public DbSet<tb_Status> tb_Status { get; set; }
        public DbSet<tb_Variant> tb_Variant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new tb_ProductConfiguration());
            modelBuilder.ApplyConfiguration(new tb_VariantConfiguration());
            modelBuilder.ApplyConfiguration(new tb_StatusConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
