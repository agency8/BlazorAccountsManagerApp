namespace BlazorAccountsManager.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> UserLogin(LoginDto user);
        Task<ServiceResponse<int>> UserRegister(RegisterDto user);
        Task<ServiceResponse<int>> CreateUserAccount(UserAccountDto user);
        Task<ServiceResponse<int>> UpdateUserAccount(UserAccountDto user);
        Task<ServiceResponse<int>> DeleteUserAccount(string userId);
        string GetUserId();
    }
}
