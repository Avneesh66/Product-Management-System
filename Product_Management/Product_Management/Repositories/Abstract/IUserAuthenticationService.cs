using Product_Management.Models.DTO;

namespace Product_Management.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> loginAsync(LoginModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();

    }
}
