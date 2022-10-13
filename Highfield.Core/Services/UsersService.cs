using Highfield.Core.Models;
using Highfield.Core.Services.External;

namespace Highfield.Core.Services
{
    public class UsersService : IUsersService
    {
        private IHighfieldDataService _highfieldDataService;

        public UsersService()
        {
            _highfieldDataService = new HighfieldDataService();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var data = await _highfieldDataService.GetUsersTestData();
            return data.Select(user => new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.Dob,
                FavouriteColour = user.FavouriteColour
            });
        }

        public async Task<FavouriteColourStatistics> GetFavouriteColourStatistics()
        {
            var users = await GetUsers();
            return new FavouriteColourStatistics(users.Select(x => x.FavouriteColour));
        }
    }
}
