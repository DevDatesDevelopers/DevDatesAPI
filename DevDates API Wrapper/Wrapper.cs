using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DevDatesApiWrapper
{
    public class DevDatesApiWrapper
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://api.devdates.com/";

        public DevDatesApiWrapper()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<User> GetUser(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{id}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(json);
        }

        public async Task<Photo[]> GetPhotos(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{id}/photos");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Photo[]>(json);
        }
        
        public async Task<Interest[]> GetInterests(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{id}/interests");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Interest[]>(json);
        }

        public async Task<ConnectedService[]> GetConnectedServices(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{id}/connected-services");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ConnectedService[]>(json);
        }

        public async Task<SexualPreference[]> GetSexualPreferences(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{id}/sexual-preferences");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SexualPreference[]>(json);
        }

        public async Task<ShortUserInfo> GetShortUserInfo(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{id}/short-info");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ShortUserInfo>(json);
        }

        public async Task<DetailedUserInfo> GetDetailedUserInfo(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{id}/detailed-info");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DetailedUserInfo>(json);
        }

        public async Task<Photo> GetPhoto(int id, int photoId)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}users/{id}/photos/{photoId}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Photo>(json);
        }
        
        

        public class User
        {
            public ShortUserInfo ShortInfo { get; set; }
            public DetailedUserInfo DetailedInfo { get; set; }
            public ConnectedService[] ConnectedServices { get; set; }
        }

        public record ShortUserInfo
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public SexualPreference[] SexualPreferences { get; set; }
            public Photo[] Photos { get; set; }
        }

        public record DetailedUserInfo
        {
            public ShortUserInfo? ShortInfo { get; set; }
            public string Bio { get; set; }
            public Interest[] Interests { get; set; }
        }

        public record ConnectedService
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }

        public record SexualPreference
        {
            public string Gender { get; set; }
            public string Orientation { get; set; }
        }

        public record Photo
        {
            public string Url { get; set; }
            public string Description { get; set; }
        }

        public record Interest
        {
            public string Name { get; set; }
            public string Category { get; set; }
        }
    }
}
