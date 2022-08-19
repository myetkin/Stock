using MediatR;

namespace Stock.Business.Commands.Variants
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
