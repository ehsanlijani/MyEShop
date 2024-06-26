using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyEShop.Api.Extensions;
using MyEShop.Application.Wrappers;

namespace MyEShop.Api.Controllers;

[ApiController]
[Route("api/V1/[controller]/[action]")]
public class BaseController(ISender sender) : ControllerBase
{
    protected readonly ISender MediatR = sender;

    protected IActionResult OK<T>(Result<T> response)
        => response.IsSuccess || response.Error.Type == ErrorType.None ? Ok(response) : (IActionResult)Ok(response.MapToProblemDetails());
}
