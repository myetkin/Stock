using MediatR;

namespace Stock.Business.Commands.UpdateProduct
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int StatusRef { get; set; }
    }
}
