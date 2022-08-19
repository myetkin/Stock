using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Stock.Data.EF;

namespace Stock.Business.Commands.UpdateProduct
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
            var product = _stockDbContext.tb_Product.Where(c => c.Id == request.Id).FirstOrDefault();

            if (!string.IsNullOrEmpty(request.Name)) product.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Code)) product.Code = request.Code;
        
            if (request.StatusRef > 0) product.StatusRef = request.StatusRef;

            await _stockDbContext.SaveChangesAsync(cancellationToken);

            return new Response();
        }
    }
}
