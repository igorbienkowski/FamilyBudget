namespace FamilyBudget.WebAPI.Services;

using DTOs.Request;
using DTOs.Response;
using Models;
using Microsoft.EntityFrameworkCore;

public class SharedBudgetService : ISharedBudgetService
{
    private readonly AppDbContext _context;

    public SharedBudgetService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<SharedBudgetResponseDto> ShareBudgetAsync(SharedBudgetRequestDto sharedBudgetRequestDto, string userId)
    {
        var budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == sharedBudgetRequestDto.BudgetId);
        
        if (budget == null || budget.UserId != userId)
        {
            return null;
        }

        var newSharedBudget = new SharedBudget
        {
            BudgetId = budget.Id,
            SharedWithUserId = sharedBudgetRequestDto.SharedWithUserId,
            SharedAt = DateTime.Now
        };

        _context.SharedBudgets.Add(newSharedBudget);
        await _context.SaveChangesAsync();

        return new SharedBudgetResponseDto
        {
            BudgetId = newSharedBudget.BudgetId,
            SharedWithUserId = newSharedBudget.SharedWithUserId,
            Id = newSharedBudget.Id,
            SharedAt = newSharedBudget.SharedAt
        };
    }

    public async Task<IEnumerable<SharedBudgetResponseDto>> GetSharedBudgetsAsync(string userId)
    {
        return await _context.SharedBudgets
            .Where(sb => sb.Budget.UserId == userId)
            .Select(sb => new SharedBudgetResponseDto { Id = sb.Id, SharedAt = sb.SharedAt, BudgetId = sb.BudgetId, SharedWithUserId = sb.SharedWithUserId })
            .ToListAsync();
    }
}