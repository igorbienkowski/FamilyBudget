namespace FamilyBudget.WebAPI.Models;

using Enums;

public class BudgetItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public BudgetItemType Type { get; set; } // "income" or "expense"
    public DateTime CreatedAt { get; set; }

    // Foreign key for Budget
    public Guid BudgetId { get; set; }

    // Navigation property
    public Budget Budget { get; set; }
}