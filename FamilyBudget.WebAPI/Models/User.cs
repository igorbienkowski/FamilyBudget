using Microsoft.AspNetCore.Identity;

namespace FamilyBudget.WebAPI.Models;

public class User : IdentityUser
{
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public List<Budget> Budgets { get; set; }
    public List<SharedBudget> SharedBudgets { get; set; }
}