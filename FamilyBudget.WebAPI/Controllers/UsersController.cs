namespace FamilyBudget.WebAPI.Controllers;

using DTOs.Request;
using Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto userRegistrationRequestDto)
    {
        var result = await _userService.RegisterUserAsync(userRegistrationRequestDto);

        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginRequestDto userLoginRequestDto)
    {
        var result = await _userService.AuthenticateUserAsync(userLoginRequestDto);

        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        return Unauthorized();
    }
}