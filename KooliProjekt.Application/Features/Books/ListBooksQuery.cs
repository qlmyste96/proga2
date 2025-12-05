using System.Collections.Generic;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Books
{
    public class ListBooksQuery : IRequest<OperationResult<IList<Book>>>
    {
    }
}
