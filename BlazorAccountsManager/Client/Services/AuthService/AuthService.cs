using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace BlazorAccountsManager.Client.Services.AuthService
{
	public class AuthService : IAuthService
	{
		private readonly HttpClient _httpClient;
		private readonly AuthenticationStateProvider _authenticationStateProvider;
		private readonly ILocalStorageService _localStorage;
		private readonly AuthenticationStateProvider _authStateProvider;

		public AuthService(HttpClient httpClient,
						   AuthenticationStateProvider authenticationStateProvider,
						   ILocalStorageService localStorage,
						   AuthenticationStateProvider authStateProvider)
		{
			_httpClient = httpClient;
			_authenticationStateProvider = authenticationStateProvider;
			_localStorage = localStorage;
			_authStateProvider = authStateProvider;
		}


		public async Task<ServiceResponse<string>> Login(LoginDto loginDto)
		{
			var response = await _httpClient.PostAsJsonAsync("api/auth/Login", loginDto);
			var result = await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
			if (result.Success)
			{
				await _localStorage.SetItemAsync("authToken", result.Data);
				((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(result.Data);
				_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Data);
				return result;
			}
			return result;
		} //Login


		public async Task<ServiceResponse<int>> Register(RegisterDto registerDto)
		{
			var response = await _httpClient.PostAsJsonAsync("api/auth/Register", registerDto);
			var result = await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
			return result;
		}


		public async Task<bool> IsUserAuthenticated()
		{
			return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
		} //IsUserAuthenticated


		public async Task Logout()
		{
			await _localStorage.RemoveItemAsync("authToken");
			((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
			_httpClient.DefaultRequestHeaders.Authorization = null;
		} //Logout


	}
}
