namespace BlazorAccountsManager.Server.Services.UserAccountService
{
    public class UserAccountService : IUserAccountService
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserAccountService(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        

        public async Task<ServiceResponse<List<UserAccountDto>>> GetUserAccounts()
        {
            var response = new ServiceResponse<List<UserAccountDto>>();
            List<UserAccountDto> userList = new List<UserAccountDto>();
            var users = await _userManager.Users.Select(x => new ApplicationUser
            {
                Id = x.Id,
                UserName = x.UserName,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DisplayName = x.DisplayName,
                PasswordHash = "*****"
            }).ToListAsync();

            if (users.Count() <= 0) 
            {
                response.Success = false;
                response.Message = "Sorry, No user accounts found";
            } 
            else 
            {
                foreach (var user in users)
                {
                    var isSuperUser = await _userManager.IsInRoleAsync(user, "SuperAdmin");

                    var roles = await _userManager.GetRolesAsync(user);
                    var userRole = roles.FirstOrDefault();


                    userList.Add(new UserAccountDto
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DisplayName = user.DisplayName,
                        UserRole = userRole,
                        IsSuperUser = isSuperUser
                    });
                }
                response.Success = true;
                response.Data = userList.ToList();                
            }
            return response;
        } //GetUserAccounts



        public async Task<ServiceResponse<UserAccountDto>> GetUserDetails(string userId)
        {
            var response = new ServiceResponse<UserAccountDto>();
            var foundUser = await _userManager.FindByIdAsync(userId);
            var user = new UserAccountDto();

            if (foundUser == null)
            {
                response.Success = true;
                response.Message = "Sorry, The user account is not found";
            }
            else
            {
                var roles = await _userManager.GetRolesAsync(foundUser);
                var userRole = roles.FirstOrDefault();


                user.UserId = foundUser.Id;
                user.UserName = foundUser.UserName;
                user.Email = foundUser.Email;
                user.FirstName = foundUser.FirstName;
                user.LastName = foundUser.LastName;
                user.DisplayName = foundUser.DisplayName;
                user.UserRole = userRole;  
                user.Notes = foundUser.Notes;

                response.Success = true;
                response.Data = user;
            }

            return response;
        } //GetUserDetails










    }
}
