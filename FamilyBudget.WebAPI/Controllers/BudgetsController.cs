using System.Security.Claims;

namespace FamilyBudget.WebAPI.Controllers;

using Services;
using DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Authorize]
[Route("Api/[controller]")]
public class BudgetsController : ControllerBase
{
    private readonly IBudgetService _budgetService;

    public BudgetsController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBudgets()
    {
        var budgets = await _budgetService.GetAllBudgetsAsync(GetUserId());
        return Ok(budgets);
    }

    [HttpGet("{budgetId}")]
    public async Task<IActionResult> GetBudget(Guid budgetId)
    {
        var budget = await _budgetService.GetBudgetAsync(budgetId, GetUserId());
        if (budget == null)
        {
            return NotFound();
        }
        return Ok(budget);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBudget(CreateBudgetRequestDto createBudgetRequestDto)
    {
        var createdBudget = await _budgetService.CreateBudgetAsync(createBudgetRequestDto, GetUserId());
        return CreatedAtAction(nameof(CreateBudget), new { budgetId = createdBudget.Id }, createdBudget);
    }

    [HttpPut("{budgetId}")]
    public async Task<IActionResult> UpdateBudget(UpdateBudgetRequestDto updateBudgetRequestDto)
    {
        var updatedBudget = await _budgetService.UpdateBudgetAsync(updateBudgetRequestDto, GetUserId());
        if (updatedBudget == null)
        {
            return NotFound();
        }
        return Ok(updatedBudget);
    }

    [HttpDelete("{budgetId}")]
    public async Task<IActionResult> DeleteBudget(Guid budgetId)
    {
        var isDeleted = await _budgetService.DeleteBudgetAsync(budgetId, GetUserId());
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    private string GetUserId()
    {
        return User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}