using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEShop.Application.UseCases.Products.Commands.Add;
using MyEShop.Application.UseCases.Products.Commands.Delete;
using MyEShop.Application.UseCases.Products.Commands.Update;
using MyEShop.Application.UseCases.Products.Queries.GetAllProducts;

namespace MyEShop.Api.Controllers.V1;

public class ProductController(ISender sender) : BaseController(sender)
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(new GetAllProductsQuery(), cancellationToken));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] AddProductCommand addProductCommand, CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(addProductCommand, cancellationToken));

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Edit([FromBody] UpdateProductCommand updateProductCommand, CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(updateProductCommand, cancellationToken));

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommand deleteProductCommand, CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(deleteProductCommand, cancellationToken));

    [AllowAnonymous]
    [HttpGet("ThrowException")]
    public IActionResult ThrowException()
    {
        throw new Exception("This is a test exception.");
    }
}
