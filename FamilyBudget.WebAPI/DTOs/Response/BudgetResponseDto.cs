using FamilyBudget.WebAPI.Models;

namespace FamilyBudget.WebAPI.DTOs.Response;

public class BudgetResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserId { get; set; }
    public List<BudgetItemResponseDto> BudgetItems { get; set; }
    public List<SharedBudgetResponseDto> SharedBudgets { get; set; }
    
}