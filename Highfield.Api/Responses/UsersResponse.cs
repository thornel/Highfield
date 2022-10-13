namespace Highfield.Api.Responses
{
    public class UsersResponse
    {
        public IEnumerable<UserDto> Users { get; set; }
    }

    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
