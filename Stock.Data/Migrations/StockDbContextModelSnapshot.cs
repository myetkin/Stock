// <auto-generated />
using Stock.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Stock.Data.Migrations
{
    [DbContext(typeof(StockDbContext))]
    partial class StockDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stock.Data.tb_Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);


                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");


                    b.Property<int>("StatusRef")
                        .HasColumnType("int");


                    b.HasKey("Id");

                    b.HasIndex("StatusRef");

                    b.ToTable("tb_Product", "dbo");
                });

            modelBuilder.Entity("Stock.Data.tb_Variant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("tb_Variant", "dbo");
                });

            modelBuilder.Entity("Stock.Data.tb_Status", b =>
                {
                    b.Property<int>("StatusRef")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusRef");

                    b.ToTable("tb_Status", "dbo");
                });

            modelBuilder.Entity("Stock.Data.tb_Product", b =>
                {
                
                    b.HasOne("Stock.Datatb_Status", "StatusRefNavigation")
                        .WithMany("tb_Product")
                        .HasForeignKey("StatusRef")
                        .HasConstraintName("FK_tb_Product_tb_Variant")
                        .IsRequired();

                    

                    b.Navigation("StatusRefNavigation");
                });

            modelBuilder.Entity("Stock.Data.tb_Variant", b =>
                {
                    b.Navigation("tb_Product");
                });

            modelBuilder.Entity("Stock.Data.tb_Status", b =>
                {
                    b.Navigation("tb_Product");
                });
#pragma warning restore 612, 618
        }
    }
}
