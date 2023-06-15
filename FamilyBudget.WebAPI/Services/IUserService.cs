namespace FamilyBudget.WebAPI.Services;

using DTOs.Request;
using Models;

public interface IUserService
{
    public Task<ServiceResult<User>> RegisterUserAsync(UserRegistrationRequestDto requestUserRegistrationDto);

    public Task<ServiceResult<string>> AuthenticateUserAsync(UserLoginRequestDto requestUserLoginDto);
}