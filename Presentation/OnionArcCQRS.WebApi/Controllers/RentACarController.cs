using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArcCQRS.Application.Features.Mediator.Queries.RentACarQueries;

namespace OnionArcCQRS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int LocationID,bool Available)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                Available = Available,
                LocationID = LocationID
            };
            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
         
    }
}
