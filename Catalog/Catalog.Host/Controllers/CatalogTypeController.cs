using System.Net;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogTypeController> logger,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddTypeResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> CreateProduct(CreateTypeRequest request)
    {
        var result = await _catalogTypeService.CreateTypeAsync(request.Type);
        return Ok(new AddItemResponse<int>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteTypeResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete(int id)
    {
        await _catalogTypeService.DeleteProductAsync(id);
        return Ok(new DeleteTypeResponse<int>() { Id = id });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateItemResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Update(UpdateProductRequest request)
    {
        await _catalogTypeService.UpdateProductAsync(request.Id, request.Name);
        return Ok(new UpdateItemResponse<int>() { Id = request.Id });
    }
}
