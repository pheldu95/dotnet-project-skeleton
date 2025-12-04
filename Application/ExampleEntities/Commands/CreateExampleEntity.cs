using Domain;
using MediatR;
using Persistence;

namespace Application.ExampleEntities.Commands;

public class CreateExampleEntity
{
    public class Command : IRequest<string>
    {
        public required ExampleEntity ExampleEntity { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.ExampleEntities.Add(request.ExampleEntity);

            await context.SaveChangesAsync(cancellationToken);

            //even though it's a "command", we will return the Id.
            return request.ExampleEntity.Id;
        }
    }
}