using MediatR;

namespace Stock.Business.Commands.Products
{
    public class Request : IRequest<Response>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int StatusRef { get; set; }
    }
}
