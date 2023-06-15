namespace FamilyBudget.WebAPI.DTOs.Request;

public class CreateBudgetRequestDto
{
    public string Name { get; set; }
    public ICollection<CreateBudgetItemRequestDto> BudgetItems { get; set; }
}