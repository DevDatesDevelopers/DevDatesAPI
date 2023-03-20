/*
using DevDates.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace DevDatesAPI.Controllers.Wrapper_test
{
    [ApiController]
    [Route("[controller]")]
    public class Wrapper
    {
        private string FullUrl;

        [HttpGet("User/short/{id}", Name = "TestURLShotInfo")]
        public async Task<ShortUserInfo> TestURLShotInfo(string url, int id)
        {
            // https://localhost:7212/User/short/1

            FullUrl = url + id;

            //Console.WriteLine(FullUrl);

            using var client = new HttpClient();
            var content = await client.GetStringAsync(FullUrl);

            var jsonFormat = JsonConvert.DeserializeObject<User>(content);

            //Console.WriteLine(jsonFormat.ShortInfo);

            ShortUserInfo user = new ShortUserInfo()
            {
                Name = jsonFormat.ShortInfo.Name,
                Age = jsonFormat.ShortInfo.Age,
                Gender  = jsonFormat.ShortInfo.Gender,
                SexualPreferences = jsonFormat.ShortInfo.SexualPreferences,
                Photos = jsonFormat.ShortInfo.Photos
            };

            //Console.WriteLine(user);

            return user;
        }

        [HttpGet("User/detailed/{id}", Name = "TestURLDetailedUserInfo")]
        public async Task<DetailedUserInfo> TestURLDetailedUserInfo(string url, int id)
        {
            // https://localhost:7212/User/detailed/1

            FullUrl = url + id;

            //Console.WriteLine(FullUrl);

            using var client = new HttpClient();
            var content = await client.GetStringAsync(FullUrl);

            var jsonFormat = JsonConvert.DeserializeObject<User>(content);

            //Console.WriteLine(jsonFormat.ShortInfo);

            DetailedUserInfo user = new DetailedUserInfo()
            {
                ShortInfo = jsonFormat.DetailedInfo.ShortInfo,
                Bio = jsonFormat.DetailedInfo.Bio,
                Interests = jsonFormat.DetailedInfo.Interests
            };

            //Console.WriteLine(user);

            return user;
        }

        [HttpGet("User/{id}", Name = "TestURLUser")]
        public async Task<User> TestURLUser(string url, int id)
        {
            // https://localhost:7212/User/full/1

            FullUrl = url + id;

           // Console.WriteLine(FullUrl);

            using var client = new HttpClient();
            var content = await client.GetStringAsync(FullUrl);

            var jsonFormat = JsonConvert.DeserializeObject<User>(content);

            //Console.WriteLine(jsonFormat.ShortInfo);

            User user = new User()
            {
                ShortInfo = jsonFormat.ShortInfo,
                DetailedInfo = jsonFormat.DetailedInfo,
                ConnectedServices = jsonFormat.ConnectedServices
            };

            //Console.WriteLine(user);

            return user;
        }
    }
}
*/