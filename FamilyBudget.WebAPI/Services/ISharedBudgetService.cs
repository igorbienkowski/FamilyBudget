namespace FamilyBudget.WebAPI.Services;

using DTOs.Request;
using DTOs.Response;

public interface ISharedBudgetService
{
    Task<SharedBudgetResponseDto> ShareBudgetAsync(SharedBudgetRequestDto sharedBudgetRequestDto, string userId);
    Task<IEnumerable<SharedBudgetResponseDto>> GetSharedBudgetsAsync(string userId);
}