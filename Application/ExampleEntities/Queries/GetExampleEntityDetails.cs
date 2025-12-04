using Domain;
using MediatR;
using Persistence;

namespace Application.ExampleEntitys.Queries;

public class GetExampleEntityDetails
{
    public class Query : IRequest<ExampleEntity>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, ExampleEntity>
    {
        public async Task<ExampleEntity> Handle(Query request, CancellationToken cancellationToken)
        {
            var exampleEntity = await context.ExampleEntities.FindAsync([request.Id], cancellationToken);

            if (exampleEntity == null) throw new Exception("ExampleEntity not found");

            return exampleEntity;
        }
    }
}