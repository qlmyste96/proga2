using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Authors
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, OperationResult<object>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAuthorQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<object>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<object>();

            result.Value = await _dbContext
                .Authors
                .Include(author => author.Books)
                .Where(author => author.Id == request.Id)
                .Select(author => new
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Books = author.Books.Select(book => new
                    {
                        book.Id,
                        book.Title,
                        book.Year
                    })
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
