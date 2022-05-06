
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAccountsManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }




        [HttpGet("GetUserAccounts")]
        [Authorize(Policy = "IsSuperAdmin")]
        public async Task<ActionResult<ServiceResponse<List<UserAccountDto>>>> GetUserAccounts()
        {
            var result = await _userAccountService.GetUserAccounts();
            return result;
        } //GetUserAccounts


        [HttpGet("GetUserDetails/{userId}")]
        public async Task<ActionResult<ServiceResponse<UserAccountDto>>> GetUserDetails(string userId)
        {
            var result = await _userAccountService.GetUserDetails(userId);
            return result;
        } //GetUserAccount


    }
}
