using Microsoft.AspNetCore.Authorization;

namespace BlazorAccountsManager.Shared.Helpers
{
	public static class Policies
	{
		public const string IsSuperAdmin = "IsSuperAdmin";
		public const string IsAdmin = "IsAdmin";
		public const string IsUser = "IsUser";


		public static AuthorizationPolicy IsSuperAdminPolicy()
		{
			return new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.RequireRole("SuperAdmin")
				.Build();
		}

		public static AuthorizationPolicy IsAdminPolicy()
		{
			return new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.RequireRole("Administrator")
				.Build();
		}

		public static AuthorizationPolicy IsUserPolicy()
		{
			return new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
					.RequireRole("User", "Registered")
					.Build();
		}
	}
}
