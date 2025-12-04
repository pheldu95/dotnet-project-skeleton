using MediatR;
using Persistence;

namespace Application.ExampleEntities.Commands;

public class DeleteExampleEntity
{
    public class Command : IRequest
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var exampleEntity = await context.ExampleEntities
                .FindAsync([request.Id], cancellationToken)
                    ?? throw new Exception("Cannot find exampleEntity"); //if returns null, then throw exception

            context.Remove(exampleEntity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}