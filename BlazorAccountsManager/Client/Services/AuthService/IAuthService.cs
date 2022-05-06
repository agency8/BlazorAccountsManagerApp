namespace BlazorAccountsManager.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Login(LoginDto loginDto);
        Task<ServiceResponse<int>> Register(RegisterDto registerDto);
        Task Logout();
        Task<bool> IsUserAuthenticated();
    }
}
