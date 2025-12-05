using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Books
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetBookQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Books
                .Include(book => book.Author)
                .Where(book => book.Id == request.Id)
                .Select(book => new
                {
                    Id = book.Id,
                    Title = book.Title,
                    Year = book.Year,
                    Author = new
                    {
                        book.Author.Id,
                        book.Author.FirstName,
                        book.Author.LastName
                    }
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
