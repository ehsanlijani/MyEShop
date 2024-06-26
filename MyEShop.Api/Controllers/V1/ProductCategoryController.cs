using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEShop.Application.UseCases.ProductCategory.Commands.Add;
using MyEShop.Application.UseCases.ProductCategory.Commands.Delete;
using MyEShop.Application.UseCases.ProductCategory.Commands.Update;
using MyEShop.Application.UseCases.ProductCategory.Queries.GetAllProductCategories;

namespace MyEShop.Api.Controllers.V1;

[Authorize]
public class ProductCategoryController(ISender sender) : BaseController(sender)
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(new GetAllProductCategoriesQuery() , cancellationToken));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] AddProductCategoryCommand addProductCategoryCommand, CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(addProductCategoryCommand , cancellationToken));


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateProductCategoryCommand updateProductCategoryCommand, CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(updateProductCategoryCommand , cancellationToken));

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCategoryCommand deleteProductCategoryCommand, CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(deleteProductCategoryCommand , cancellationToken));
}
