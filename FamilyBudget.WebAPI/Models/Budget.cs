namespace FamilyBudget.WebAPI.Models;

public class Budget
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    // Foreign key for User
    public string UserId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public List<BudgetItem> BudgetItems { get; set; }
    public List<SharedBudget> SharedBudgets { get; set; }
}