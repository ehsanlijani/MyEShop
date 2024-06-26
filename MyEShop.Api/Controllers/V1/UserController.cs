using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyEShop.Application.UseCases.User.Commands.LogIn;
using MyEShop.Application.UseCases.User.Commands.Register;

namespace MyEShop.Api.Controllers.V1;


public class UserController(ISender sender) : BaseController(sender)
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(registerUserCommand , cancellationToken));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LogIn(LogInUserCommand registerUserCommand, CancellationToken cancellationToken = default)
        => Ok(await MediatR.Send(registerUserCommand, cancellationToken));
}

