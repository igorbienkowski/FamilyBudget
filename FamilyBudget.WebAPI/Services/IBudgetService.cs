namespace FamilyBudget.WebAPI.Services;

using DTOs.Request;
using DTOs.Response;

public interface IBudgetService
{
    Task<IEnumerable<BudgetResponseDto>> GetAllBudgetsAsync(string userId);
    Task<BudgetResponseDto> GetBudgetAsync(Guid budgetId, string userId);
    Task<BudgetResponseDto> CreateBudgetAsync(CreateBudgetRequestDto responseBudget, string userId);
    Task<BudgetResponseDto> UpdateBudgetAsync(UpdateBudgetRequestDto responseBudget, string userId);
    Task<bool> DeleteBudgetAsync(Guid budgetId, string userId);
}