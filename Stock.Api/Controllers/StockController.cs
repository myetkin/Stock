using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Stock.API.Controllers
{

    public interface IDispatcher : IMediator
    {
    }
    [ApiController]
    [Route("stocks/api/[controller]")]
    public class StockController : ControllerBase
    {
       
        //private readonly ILogger<StockController> _logger;
        private readonly IMediator _mediator;

        public StockController( IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost()]
        public async Task<ActionResult> Requestm()
        {
            return Ok();
        }

        [HttpGet("product")]
        public async Task<ActionResult> Product([FromQuery] Business.Queries.ListOfProductByFilter.Request request)
        {
            var products = await _mediator.Send(request);
            return Ok(products);
        }
         
        [HttpGet("variant")]
        public async Task<ActionResult> Variant([FromQuery] Business.Queries.ListOfVariantByFilter.Request request)
        {
            var variants= await _mediator.Send(request);
            return Ok(variants);
        }

        //[HttpPost("createCustomer")]
        ////[ProducesResponseType(typeof(tb_Customer), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult> CreateCustomer([FromBody] Business.Commands.CreateCustomer.Request request)
        //{
        //    var customers = await _mediator.Send(request);
        //    return Ok(customers);
        //}
    }
}
