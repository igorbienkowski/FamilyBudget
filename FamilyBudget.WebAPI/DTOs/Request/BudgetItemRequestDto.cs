namespace FamilyBudget.WebAPI.DTOs.Request;

using Enums;

public class BudgetItemRequestDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public BudgetItemType Type { get; set; } // "income" or "expense"
    public Guid BudgetId { get; set; }
}