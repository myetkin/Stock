using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Data.EF
{
    public class StockContextSeed
    {
        public static async Task SeedAsync(StockDbContext StockDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                StockDbContext.Database.Migrate();

                if (!StockDbContext.tb_Variant.AsNoTracking().Any())
                {
                    StockDbContext.tb_Variant.AddRange(GetPreconfiguredVariants());
                    await StockDbContext.SaveChangesAsync();
                }
                if (!StockDbContext.tb_Status.AsNoTracking().Any())
                {
                    StockDbContext.tb_Status.AddRange(GetPreconfiguredStatuses());
                    await StockDbContext.SaveChangesAsync();
                }
                if (!StockDbContext.tb_Product.AsNoTracking().Any())
                {
                    StockDbContext.tb_Product.AddRange(GetPreconfiguredProduct());
                    await StockDbContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<StockContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(StockDbContext, loggerFactory, retryForAvailability);
                }

                throw;
            }
        }

        private static IEnumerable<tb_Status> GetPreconfiguredStatuses()
        {
            return new List<tb_Status>
            {
                new tb_Status()
                {
                    Status = "Taken for processing"
                },
                new tb_Status()
                {
                    Status = "Qualified"
                },
                new tb_Status()
                {
                    Status = "Out of scope"
                }
            };
        }

        private static IEnumerable<tb_Variant> GetPreconfiguredVariants()
        {
            return new List<tb_Variant>
            {
                new tb_Variant() { Name = "LEft", Code = "LEFT" },
                new tb_Variant() { Name = "Right", Code = "RIGHT" }
            };
        }

        private static IEnumerable<tb_Product> GetPreconfiguredProduct()
        {
            return new List<tb_Product>
            {
                new tb_Product()
                {
                    Name = "test",
                    Code = "TESTODE",
                    StatusRef = 2
                },
                new tb_Product()
                {
                    Name = "mine",
                    Code = "GOLD",
                    StatusRef = 1
                }, 
                new tb_Product()
                {
                    Name = "mine2",
                    Code = "SILVER",
                    StatusRef = 2
                },
                new tb_Product()
                {
                    Name = "mine3",
                    Code = "TOST",
                    StatusRef = 3
                },
            };
        }
    }
}
