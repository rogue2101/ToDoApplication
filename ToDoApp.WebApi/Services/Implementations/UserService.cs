using Microsoft.AspNetCore.Identity;
using ToDoApp.WebApi.DAL.Identity;
using ToDoApp.WebApi.Services.Interfaces;

namespace ToDoApp.WebApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> RegisterUserAsync(string username, string password)
        {
            var user = new ApplicationUser { UserName = username };
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> SignInUserAsync(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
        }
    }
}
