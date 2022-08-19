using MediatR;
using System.Collections.Generic;

namespace Stock.Business.Queries.GetQualifiedProductRef
{
    public class Request : IRequest<List<Response>>
    {
        public int CountryRef { get; set; }
    }
}
