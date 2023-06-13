namespace FamilyBudget.WebAPI.Models;

public class BudgetItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } // "income" or "expense"
    public DateTime CreatedAt { get; set; }

    // Foreign key for Budget
    public int BudgetId { get; set; }

    // Navigation property
    public Budget Budget { get; set; }
}