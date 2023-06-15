using FamilyBudget.WebAPI.Enums;

namespace FamilyBudget.WebAPI.DTOs.Request;

public class CreateBudgetItemRequestDto
{
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public BudgetItemType Type { get; set; } // "income" or "expense"
}