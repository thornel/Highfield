using Highfield.Api.Responses;
using Highfield.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Highfield.Api.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService _userService;

        public UsersController()
        {
            _userService = new UsersService();
        }
            
        [HttpGet]
        public async Task<UsersResponse> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return new UsersResponse
            {
                Users = users.Select(user => new UserDto
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age
                })
            };
        }
    }
}
