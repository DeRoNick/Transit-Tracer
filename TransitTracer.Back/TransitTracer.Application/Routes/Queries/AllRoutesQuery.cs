using MediatR;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Domain.Models;

namespace TransitTracer.Application.Routes.Queries;

public class AllRoutesQuery : IRequest<IEnumerable<Route>>
{
}

public class AllRoutesQueryHandler : IRequestHandler<AllRoutesQuery, IEnumerable<Route>>
{
    private readonly IRoutesRepository _repo;

    public AllRoutesQueryHandler(IRoutesRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Route>> Handle(AllRoutesQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAll(cancellationToken).ConfigureAwait(false);
    }
}