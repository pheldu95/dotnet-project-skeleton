using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.ExampleEntities.Commands;

public class EditExampleEntity
{
     public class Command : IRequest
    {
        public required ExampleEntity ExampleEntity { get; set; }
    }

    public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var exampleEntity = await context.ExampleEntities
                .FindAsync([request.ExampleEntity.Id], cancellationToken)
                    ?? throw new Exception("Cannot find Example Entity"); //if returns null, then throw exception

            mapper.Map(request.ExampleEntity, exampleEntity);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}