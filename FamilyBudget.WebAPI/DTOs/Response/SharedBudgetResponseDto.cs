namespace FamilyBudget.WebAPI.DTOs.Response;

public class SharedBudgetResponseDto
{
    public Guid Id { get; set; }
    public DateTime SharedAt { get; set; }
    public Guid BudgetId { get; set; }
    public string SharedWithUserId { get; set; }
}