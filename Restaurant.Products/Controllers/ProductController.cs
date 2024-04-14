using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Infra.Contexts;

namespace Restaurant.Products.Controllers;

//[Produces("application/json")]
//[ApiVersion("1.0")]
//[Route("/api/v{version:apiVersion}/Educacional/[controller]")]
[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    public ProductController() : base() { }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
    [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> GetAsync(RestaurantDbContext dbContext, CancellationToken cancellationToken = default)
    {
        return Ok(await dbContext.Products.ToListAsync());
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
    [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
    [ProducesResponseType(typeof(ProblemDetails), 500)]
    public async Task<IActionResult> AddAsync(RestaurantDbContext dbContext, Product product, CancellationToken cancellationToken = default)
    {
        var entity = await dbContext.Products.AddAsync(product, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Ok(entity.Entity);
    }
}