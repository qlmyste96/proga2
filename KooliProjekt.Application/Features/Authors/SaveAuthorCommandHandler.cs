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

namespace KooliProjekt.Application.Features.Authors
{
    public class SaveAuthorCommandHandler : IRequestHandler<SaveAuthorCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveAuthorCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveAuthorCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var author = new Author();
            if (request.Id == 0)
            {
                await _dbContext.Authors.AddAsync(author);
            }
            else
            {
                author = await _dbContext.Authors.FindAsync(request.Id);
            }

            author.FirstName = request.FirstName;
            author.LastName = request.LastName;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
