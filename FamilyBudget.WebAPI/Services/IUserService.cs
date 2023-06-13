using FamilyBudget.WebAPI.DTOs;
using FamilyBudget.WebAPI.Models;

namespace FamilyBudget.WebAPI.Services;

public interface IUserService
{
    public Task<ServiceResult<User>> RegisterUserAsync(UserRegistrationDto userRegistrationDto);

    public Task<ServiceResult<string>> AuthenticateUserAsync(UserLoginDto userLoginDto);
}