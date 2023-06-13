namespace FamilyBudget.WebAPI.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public List<Budget> Budgets { get; set; }
    public List<SharedBudget> SharedBudgets { get; set; }
}