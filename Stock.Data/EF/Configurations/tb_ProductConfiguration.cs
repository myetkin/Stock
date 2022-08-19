using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stock.Data.EF.Configurations
{
    public partial class tb_ProductConfiguration : IEntityTypeConfiguration<tb_Product>
    {
        public void Configure(EntityTypeBuilder<tb_Product> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.ToTable("tb_Product", "dbo");

            builder.Property(e => e.Name).HasMaxLength(20);
            builder.Property(e => e.Code).HasMaxLength(20);


            builder.HasOne(d => d.StatusRefNavigation)
               .WithMany(p => p.tb_Product)
               .HasForeignKey(d => d.StatusRef)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_tb_Product_tb_Variant");

            builder.HasQueryFilter(c => c.IsDeleted == false);

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<tb_Product> builder);
    }
}
