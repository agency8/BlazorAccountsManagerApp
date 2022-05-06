namespace BlazorAccountsManager.Server.Services.UserAccountService
{
    public interface IUserAccountService
    {
        Task<ServiceResponse<List<UserAccountDto>>> GetUserAccounts();
        Task<ServiceResponse<UserAccountDto>> GetUserDetails(string userId);
    }
}
