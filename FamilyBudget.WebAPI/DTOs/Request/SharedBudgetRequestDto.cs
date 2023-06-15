namespace FamilyBudget.WebAPI.DTOs.Request;

public class SharedBudgetRequestDto
{
    public Guid BudgetId { get; set; }
    public string SharedWithUserId { get; set; }
}