using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stock.Data.EF.Configurations
{
    public partial class tb_VariantConfiguration : IEntityTypeConfiguration<tb_Variant>
    {
        public void Configure(EntityTypeBuilder<tb_Variant> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("tb_Variant", "dbo");


            builder.Property(e => e.Id).ValueGeneratedNever().UseIdentityColumn();

            OnConfigurePartial(builder);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<tb_Variant> builder);
    }
}
