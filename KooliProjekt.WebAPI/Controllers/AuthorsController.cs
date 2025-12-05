using System.Threading.Tasks;
using KooliProjekt.Application.Features.Authors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class AuthorsController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorsController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListAuthorsQuery query)
        {
            var response = await _mediator.Send(query);

            return Result(response);
        }
    }
}
