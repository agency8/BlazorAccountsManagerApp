using Microsoft.AspNetCore.Components;

namespace BlazorAccountsManager.Client.Pages.Admin
{
    public partial class AccountManager
    {
        [Inject] IUserAccountManager UserAccountManager { get; set; }

        bool showError = false;
        bool showInfo = false;
        string message = string.Empty;
        bool isInAccountEditMode = false;
        UserAccountDto user = new UserAccountDto();


        protected override async Task OnInitializedAsync()
        {
            await UserAccountManager.GetUserAccounts();
        } //OnInitializedAsync


        private async Task AddUserAccount()
        {
            user = new UserAccountDto();
            isInAccountEditMode = true;
        } //AddUserAccount


        private async Task EditUser(string userId)
        {
            var result = await UserAccountManager.GetUserDetails(userId);
            if (result.Success)
                user = result.Data;

            isInAccountEditMode = true;
        } //EditUser


        private void CancelEdit()
        {
            user = new UserAccountDto();
            isInAccountEditMode = false;
        } //CancelEdit


        private async Task UpdateUserAccount()
        {
            showError = false;
            showInfo = false;
            message = string.Empty;
            if (!string.IsNullOrEmpty(user.UserId))
            {
                var result = await UserAccountManager.UpdateUserAccount(user);

                if (result.Success)
                {
                    showInfo = true;
                    message = result.Message;
                }
                else
                {
                    showError = true;
                    message = result.Message;
                }
            }
            else
            {
                var result = await UserAccountManager.CreateNewUserAccount(user);
                if (result.Success)
                {
                    showInfo = true;
                    message = result.Message;
                }
                else
                {
                    showError = true;
                    message = result.Message;
                }
            }

            user = new UserAccountDto();
            await UserAccountManager.GetUserAccounts();
            isInAccountEditMode = false;
        } //UpdateUserAccount


        private async Task DeleteUser(string userId)
        {
            var result = await UserAccountManager.DeleteUserAccount(userId);
            if (result.Success)
            {
                showInfo = true;
                message = result.Message;
                await UserAccountManager.GetUserAccounts();
            }
            else
            {
                showError = true;
                message = result.Message;
            }
        } //DeleteUser



        



    }
}
