using Highfield.Core.Models;

namespace Highfield.Core.Services
{
    public interface IUsersService
    {
        Task<FavouriteColourStatistics> GetFavouriteColourStatistics();
        Task<IEnumerable<User>> GetUsers();
    }
}