using mp.security.Dtos.Auth;

namespace mp.security.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterRequest request);
        Task<string> LoginAsync(string username, string password);

    }
}
