using FamilyBudget.WebAPI.Models;

namespace FamilyBudget.WebAPI.Security;

public interface IJwtGenerator
{
    Task<string> GenerateToken(User user);
}