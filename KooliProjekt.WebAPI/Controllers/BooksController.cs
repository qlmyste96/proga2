using System.Threading.Tasks;
using KooliProjekt.Application.Features.Books;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KooliProjekt.WebAPI.Controllers
{
    public class BooksController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var query = new ListBooksQuery();
            var result = await _mediator.Send(query);

            return Result(result);
        }
    }
}
