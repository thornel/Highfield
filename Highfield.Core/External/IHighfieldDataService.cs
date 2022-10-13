using Highfield.Core.External;

namespace Highfield.Core.Services.External
{
    internal interface IHighfieldDataService
    {
        Task<IEnumerable<UserEntity>> GetUsersTestData();
    }
}