using FamilyBudget.WebAPI.DTOs;
using FamilyBudget.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudget.WebAPI.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRegistrationDto"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto userRegistrationDto)
    {
        var result = await _userService.RegisterUserAsync(userRegistrationDto);

        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        var result = await _userService.AuthenticateUserAsync(userLoginDto);

        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }
        return Unauthorized();
    }
}