namespace FamilyBudget.WebAPI.Services;

using DTOs.Request;
using Models;
using DTOs.Response;
using Microsoft.EntityFrameworkCore;

public class BudgetService : IBudgetService
{
    private readonly AppDbContext _context;

    public BudgetService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BudgetResponseDto>> GetAllBudgetsAsync(string userId)
    {
        return await _context.Budgets
            .Where(b => b.UserId == userId)
            .Select(b => new BudgetResponseDto
            {
                Id = b.Id, 
                Name = b.Name,
                CreatedAt = b.CreatedAt,
                UserId = b.UserId,
                BudgetItems = b.BudgetItems.Select(bi => new BudgetItemResponseDto
                {
                    Id = bi.Id,
                    Name = bi.Name,
                    Amount = bi.Amount,
                    Type = bi.Type,
                    CreatedAt = bi.CreatedAt,
                    BudgetId = bi.BudgetId
                }).ToList(),
                SharedBudgets = b.SharedBudgets.Select(sb => new SharedBudgetResponseDto
                {
                    BudgetId = sb.BudgetId,
                    SharedWithUserId = sb.SharedWithUserId,
                    Id = sb.Id,
                    SharedAt = sb.SharedAt
                }).ToList()
                
            })
            .ToListAsync();
    }

    public async Task<BudgetResponseDto> GetBudgetAsync(Guid budgetId, string userId)
    {
        var budget = await _context.Budgets
            .Include(b => b.BudgetItems)
            .Include(b => b.SharedBudgets)
            .FirstOrDefaultAsync(b => b.Id == budgetId);
        
        if (budget == null || budget.UserId != userId)
        {
            return null;
        }

        return new BudgetResponseDto
        {
            Id = budget.Id,
            Name = budget.Name,
            CreatedAt = budget.CreatedAt,
            UserId = budget.UserId,
            BudgetItems = (budget.BudgetItems ?? new List<BudgetItem>()).Select(bi => new BudgetItemResponseDto
            {
                Id = bi.Id,
                Name = bi.Name,
                Amount = bi.Amount,
                Type = bi.Type,
                CreatedAt = bi.CreatedAt,
                BudgetId = bi.BudgetId
            }).ToList(),
            SharedBudgets = (budget.SharedBudgets ?? new List<SharedBudget>()).Select(sb => new SharedBudgetResponseDto
            {
                BudgetId = sb.BudgetId,
                SharedWithUserId = sb.SharedWithUserId,
                Id = sb.Id,
                SharedAt = sb.SharedAt
            }).ToList()

        };
    }

    public async Task<BudgetResponseDto> CreateBudgetAsync(CreateBudgetRequestDto createBudgetRequestDto, string userId)
    {
        var budget = new Budget
        {
            Name = createBudgetRequestDto.Name,
            UserId = userId,
            CreatedAt = DateTime.Now,
            BudgetItems = createBudgetRequestDto.BudgetItems.Select(bi => new BudgetItem
            {
                Amount = bi.Amount,
                CreatedAt = DateTime.Now,
                Name = bi.Name,
                Type = bi.Type
            }).ToList()
        };

        _context.Budgets.Add(budget);
        await _context.SaveChangesAsync();

        return new BudgetResponseDto
         {
             Id = budget.Id, 
             Name = budget.Name,
             CreatedAt = budget.CreatedAt,
             UserId = budget.UserId,
             SharedBudgets = (budget.SharedBudgets ?? new List<SharedBudget>()).Select(sb => new SharedBudgetResponseDto
             {
                 BudgetId = sb.BudgetId,
                 SharedWithUserId = sb.SharedWithUserId,
                 Id = sb.Id,
                 SharedAt = sb.SharedAt
             }).ToList(),
             BudgetItems = budget.BudgetItems.Select(bi => new BudgetItemResponseDto
             {
                 Id = bi.Id,
                 Name = bi.Name,
                 Amount = bi.Amount,
                 Type = bi.Type,
                 CreatedAt = bi.CreatedAt,
                 BudgetId = bi.BudgetId
             }).ToList()
         };
    }

    public async Task<BudgetResponseDto> UpdateBudgetAsync(UpdateBudgetRequestDto updateBudgetRequestDto, string userId)
    {
        var budget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == updateBudgetRequestDto.Id);

        if (budget == null || budget.UserId != userId)
        {
            return null;
        }

        budget.Name = updateBudgetRequestDto.Name;
        budget.User = updateBudgetRequestDto.User;
        budget.UserId = updateBudgetRequestDto.UserId;
        budget.BudgetItems = updateBudgetRequestDto.BudgetItems.Select(bi => new BudgetItem
        {
            Id = bi.Id,
            Name = bi.Name,
            Amount = bi.Amount,
            Type = bi.Type,
            CreatedAt = bi.CreatedAt
        }).ToList();
        budget.SharedBudgets = updateBudgetRequestDto.SharedBudgets.Select(sb => new SharedBudget
        {
            Id = sb.BudgetId,
            SharedWithUserId = sb.SharedWithUserId
        }).ToList();

        _context.Budgets.Update(budget);
        await _context.SaveChangesAsync();

        return new BudgetResponseDto
        {
            Id = budget.Id, 
            Name = budget.Name,
            CreatedAt = budget.CreatedAt,
            BudgetItems = (budget.BudgetItems?? new List<BudgetItem>()).Select(bi => new BudgetItemResponseDto
            {
                Id = bi.Id,
                Name = bi.Name,
                Amount = bi.Amount,
                Type = bi.Type,
                CreatedAt = bi.CreatedAt
            }).ToList()
        };
    }

    public async Task<bool> DeleteBudgetAsync(Guid budgetId, string userId)
    {
        var budget = await _context.Budgets.FindAsync(budgetId);

        if (budget == null || budget.UserId != userId)
        {
            return false;
        }

        _context.Budgets.Remove(budget);
        await _context.SaveChangesAsync();

        return true;
    }
}