using Highfield.Core.External;
using Newtonsoft.Json;

namespace Highfield.Core.Services.External
{
    internal class HighfieldDataService : IHighfieldDataService
    {
        private readonly HttpClient _httpClient;

        public HighfieldDataService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://recruitment.highfieldqualifications.com/")
            };
        }

        public async Task<IEnumerable<UserEntity>> GetUsersTestData()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/test");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                var result = responseContent != null ? JsonConvert.DeserializeObject<IEnumerable<UserEntity>>(responseContent) : null;

                return result is null ? throw new Exception("Could not get data from response.") : result;
            }
            catch (Exception e)
            {
                throw new Exception("Error trying to get highfield data.", e);
            }
        }
    }
}
