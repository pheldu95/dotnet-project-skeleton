using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ExampleEntities.Queries;

public class GetExampleEntityList
{
    public class Query : IRequest<List<ExampleEntity>> {}

     public class Handler(AppDbContext context) : IRequestHandler<Query, List<ExampleEntity>>
    {
        public async Task<List<ExampleEntity>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await context.ExampleEntities.ToListAsync(cancellationToken);
        }
    }
}
