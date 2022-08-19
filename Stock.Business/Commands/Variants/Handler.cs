using Stock.Business.Exceptions;
using Stock.Data.EF;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Stock.Business.Commands.Products;

namespace Stock.Business.Commands.Variants
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly StockDbContext _stockDbContext;
        public Handler(StockDbContext StockDbContext)
        {
            _stockDbContext = StockDbContext;
        }
                
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var product = _stockDbContext.tb_Product.Where(c => c.Code == request.Code).FirstOrDefault();
            if (product == null)
            {
                throw new NotFoundException("product", request.Code);
            }

            product.IsDeleted = true;
            await _stockDbContext.SaveChangesAsync(cancellationToken);

            return new Response();
        }
    }
}
