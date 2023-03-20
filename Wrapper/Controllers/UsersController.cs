using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevDatesAPI.Controllers
{
    using System.Threading.Tasks;
    using System.Net.Http;
    using DevDates.Model.Models;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    namespace DevDatesAPI.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class UsersController : ControllerBase
        {
            private readonly HttpClient _httpClient;

            public UsersController()
            {
                _httpClient = new HttpClient();
            }

            [HttpGet("User/short/{id}", Name = "GetShortUserInfo")]
            public async Task<ActionResult<ShortUserInfo>> GetShortUserInfo(int id)
            {
                string url = $"https://localhost:7212/User/short/{id}";

                var content = await _httpClient.GetStringAsync(url);

                var jsonFormat = JsonConvert.DeserializeObject<User>(content);

                ShortUserInfo user = new ShortUserInfo()
                {
                    Name = jsonFormat.ShortInfo.Name,
                    Age = jsonFormat.ShortInfo.Age,
                    Gender = jsonFormat.ShortInfo.Gender,
                    SexualPreferences = jsonFormat.ShortInfo.SexualPreferences,
                    Photos = jsonFormat.ShortInfo.Photos
                };

                return user;
            }

            [HttpGet("User/detailed/{id}", Name = "GetDetailedUserInfo")]
            public async Task<ActionResult<DetailedUserInfo>> GetDetailedUserInfo(int id)
            {
                string url = $"https://localhost:7212/User/detailed/{id}";

                var content = await _httpClient.GetStringAsync(url);

                var jsonFormat = JsonConvert.DeserializeObject<User>(content);

                DetailedUserInfo user = new DetailedUserInfo()
                {
                    ShortInfo = jsonFormat.DetailedInfo.ShortInfo,
                    Bio = jsonFormat.DetailedInfo.Bio,
                    Interests = jsonFormat.DetailedInfo.Interests
                };

                return user;
            }

            [HttpGet("User/{id}", Name = "GetUser")]
            public async Task<ActionResult<User>> GetUser(int id)
            {
                string url = $"https://localhost:7212/User/full/{id}";

                var content = await _httpClient.GetStringAsync(url);

                var jsonFormat = JsonConvert.DeserializeObject<User>(content);

                User user = new User()
                {
                    ShortInfo = jsonFormat.ShortInfo,
                    DetailedInfo = jsonFormat.DetailedInfo,
                    ConnectedServices = jsonFormat.ConnectedServices
                };

                return user;
            }
        }
    }
}
