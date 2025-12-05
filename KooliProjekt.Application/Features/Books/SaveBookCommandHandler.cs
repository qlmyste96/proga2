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

namespace KooliProjekt.Application.Features.Books
{
    public class SaveBookCommandHandler : IRequestHandler<SaveBookCommand, OperationResult>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveBookCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult> Handle(SaveBookCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult();

            var book = new Book();
            if (request.Id == 0)
            {
                await _dbContext.Books.AddAsync(book);
            }
            else
            {
                book = await _dbContext.Books.FindAsync(request.Id);
            }

            book.Title = request.Title;
            book.Year = request.Year;
            book.AuthorId = request.AuthorId;

            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
