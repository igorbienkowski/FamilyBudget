using System.Security.Claims;

namespace FamilyBudget.WebAPI.Controllers;

using DTOs.Request;
using Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

[ApiController]
[Authorize]
[Route("Api/[controller]")]
public class SharedBudgetsController : ControllerBase
{
    private readonly ISharedBudgetService _sharedBudgetService;

    public SharedBudgetsController(ISharedBudgetService sharedBudgetService)
    {
        _sharedBudgetService = sharedBudgetService;
    }

    [HttpPost]
    public async Task<IActionResult> ShareBudget(SharedBudgetRequestDto sharedBudgetRequestDto)
    {
        var result = await _sharedBudgetService.ShareBudgetAsync(sharedBudgetRequestDto, GetUserId());
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetSharedBudgets()
    {
        var sharedBudgets = await _sharedBudgetService.GetSharedBudgetsAsync(GetUserId());
        return Ok(sharedBudgets);
    }
    
    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}