using ToDoApp.WebApi.DAL.Identity;
using ToDoApp.WebApi.Models.ResponseModel;

namespace ToDoApp.WebApi.Services.Interfaces
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(ApplicationUser applicationUser);
    }
}
