using Stock.Data;
using Stock.Data.EF;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Business.Commands.Products
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
            var product = new tb_Product
            {
                Name = request.Name,
                Code = request.Code,

                StatusRef = request.StatusRef
            };

            await _stockDbContext.tb_Product.AddAsync(product, cancellationToken);
            await _stockDbContext.SaveChangesAsync(cancellationToken);

            return new Response();
        }
    }
}
