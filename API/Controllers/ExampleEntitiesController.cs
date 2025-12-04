using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ExampleEntitiesController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<ExampleEntity>>> GetExampleEntities()
    {
        return await context.ExampleEntities.ToListAsync();
    }
}
