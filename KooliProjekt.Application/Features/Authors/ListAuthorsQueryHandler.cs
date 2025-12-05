using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Authors
{
    public class ListAuthorsQueryHandler : IRequestHandler<ListAuthorsQuery, OperationResult<IList<Author>>>
    {
        private readonly ApplicationDbContext _dbContext;
        public ListAuthorsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<IList<Author>>> Handle(ListAuthorsQuery request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<IList<Author>>();
            result.Value = await _dbContext
                .Authors
                .OrderBy(author => author.LastName)
                .ThenBy(author => author.FirstName)
                .ToListAsync();

            return result;
        }
    }
}
