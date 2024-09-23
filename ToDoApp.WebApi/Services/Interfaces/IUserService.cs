using Microsoft.AspNetCore.Identity;

namespace ToDoApp.WebApi.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> RegisterUserAsync(string username, string password);
        public Task<SignInResult> SignInUserAsync(string username, string password);
    }
}
