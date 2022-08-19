using Stock.Business.Enumerations;
using Stock.Data.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Business.Queries.GetQualifiedProductRef
{
    public class Handler : IRequestHandler<Request, List<Response>>
    {
        private readonly StockDbContext _stockDbContext;
        public Handler(StockDbContext StockDbContext)
        {
            _stockDbContext = StockDbContext;
        }
                
        public async Task<List<Response>> Handle(Request request, CancellationToken cancellationToken)
        {
            var query = _stockDbContext.tb_Product
                .Include(c => c.StatusRefNavigation)
                .Select(s => new Response
                {
                    Name = s.Name,
                    Code = s.Code,
                    Status = s.StatusRefNavigation.Status,
                });

            var products = await query.ToListAsync();

            return products;
        }
    }
}
