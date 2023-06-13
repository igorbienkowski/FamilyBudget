namespace FamilyBudget.WebAPI.Models;

public class SharedBudget
{
    public int Id { get; set; }
    public DateTime SharedAt { get; set; }

    // Foreign keys
    public int BudgetId { get; set; }
    public int SharedWithUserId { get; set; }

    // Navigation properties
    public Budget Budget { get; set; }
    public User SharedWithUser { get; set; }
}