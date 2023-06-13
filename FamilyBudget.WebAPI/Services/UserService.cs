using System.Security.Claims;
using FamilyBudget.WebAPI.DTOs;
using FamilyBudget.WebAPI.Models;
using FamilyBudget.WebAPI.Security;
using Microsoft.AspNetCore.Identity;

namespace FamilyBudget.WebAPI.Services;

public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtGenerator _jwtGenerator;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IJwtGenerator jwtGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<ServiceResult<User>> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            var user = new User
            {
                UserName = userRegistrationDto.Username,
                Email = userRegistrationDto.Email
            };
            
            var result = await _userManager.CreateAsync(user, userRegistrationDto.Password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "user"));

            if (result.Succeeded)
            {
                // User registration successful
                return ServiceResult<User>.Success(user, "User registered successfully");
            }
            else
            {
                // User registration failed
                var errors = result.Errors.Select(e => e.Description);
                return ServiceResult<User>.Failure(errors);
            }
        }

        public async Task<ServiceResult<string>> AuthenticateUserAsync(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // User authentication successful
                var user = await _userManager.FindByNameAsync(userLoginDto.Username);
                var token = await _jwtGenerator.GenerateToken(user);
                return ServiceResult<string>.Success(token, "Successfully logged in");
            }
            else
            {
                // User authentication failed
                return ServiceResult<string>.Failure("Invalid username or password");
            }
        }
    }
