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
    [ProducesResponseType(typeof(AddItemResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> CreateProduct(CreateProductRequest request)
    {
        var result = await _catalogTypeService.CreateProductAsync(request.Name);
        return Ok(new AddItemResponse<int>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteItemResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete(int id)
    {
        await _catalogTypeService.DeleteProductAsync(id);
        return Ok(new DeleteItemResponse<int>() { Id = id });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateItemResponse<int>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Update(UpdateProductRequest request)
    {
        await _catalogTypeService.UpdateProductAsync(request.Id, request.Name);
        return Ok(new UpdateItemResponse<int>() { Id = request.Id });
    }
}