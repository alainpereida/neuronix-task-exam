using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neuronix.Api.Dtos;
using Neuronix.Core.IServices;

namespace Neuronix.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _service;
    /// <summary>
    /// Este controllador se encarga de recibir las peticiones para hacer login.
    /// </summary>
    public AuthController(IAuthenticationService service)
    {
        _service = service;
    }
    
    /// <summary>
    /// Login para usuarios
    /// </summary>
    /// <remarks>
    /// Ejemplo de request:
    /// 
    ///     POST /
    ///     {
    ///         "userName": "general",
    ///         "password": "G3N3R4L!98",
    ///     }
    ///     
    /// </remarks>
    /// <returns>Regresa el usuario con el token</returns>
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLogin)
    {
        var serviceResult = await _service.Login(userForLogin.UserName, userForLogin.Password);

        if (serviceResult.Successful)
        {
            return Ok(serviceResult);
        }

        return BadRequest(serviceResult);
    }
}