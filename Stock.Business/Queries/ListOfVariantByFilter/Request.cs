using MediatR;
using System.Collections.Generic;

namespace Stock.Business.Queries.ListOfVariantByFilter
{
    public class Request : IRequest<List<Response>>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
