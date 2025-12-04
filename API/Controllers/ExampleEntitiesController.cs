using Application.ExampleEntities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

public class ExampleEntitiesController() : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<ExampleEntity>>> GetExampleEntities()
    {
        return await Mediator.Send(new GetExampleEntityList.Query());
    }
}
