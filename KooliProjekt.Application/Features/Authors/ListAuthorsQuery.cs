using System.Collections.Generic;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Authors
{
    public class ListAuthorsQuery : IRequest<OperationResult<IList<Author>>>
    {
    }
}
