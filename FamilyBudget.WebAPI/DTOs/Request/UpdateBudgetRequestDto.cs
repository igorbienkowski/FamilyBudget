using FamilyBudget.WebAPI.Models;

namespace FamilyBudget.WebAPI.DTOs.Request;

public class UpdateBudgetRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    // Foreign key for User
    public string UserId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public List<UpdateBudgetItemRequestDto> BudgetItems { get; set; }
    public List<SharedBudgetRequestDto> SharedBudgets { get; set; }
}