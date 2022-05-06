namespace BlazorAccountsManager.Client.Services.UserAccountManager
{
    public interface IUserAccountManager
    {
        event Action OnChange;
        List<UserAccountDto> UserList { get; set; }
        Task GetUserAccounts();
        Task<ServiceResponse<UserAccountDto>> GetUserDetails(string userId);
        Task<ServiceResponse<int>> CreateNewUserAccount(UserAccountDto userAccount);
        Task<ServiceResponse<int>> UpdateUserAccount(UserAccountDto userAccount);
        Task<ServiceResponse<int>> DeleteUserAccount(string userId);
    }
}
