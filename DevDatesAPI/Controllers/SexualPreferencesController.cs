using DevDates.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SexualPreferencesController
    {
        private readonly SexualPreference[] SexualPreferences =
        {
            new SexualPreference()
            {
                DisplayName = "Men",
                Photos = new []
                {
                    new Photo()
                    {
                        url = "https://picsum.photos/200/300"
                    },
                    new Photo()
                    {
                        url = "https://picsum.photos/200/300"
                    },
                    new Photo()
                    {
                        url = "https://picsum.photos/200/300"
                    }
                }
            },

            new SexualPreference()
            {
                DisplayName = "Women",
                Photos = new []
                {
                    new Photo()
                    {
                        url = "https://picsum.photos/200/300"
                    },
                    new Photo()
                    {
                        url = "https://picsum.photos/200/300"
                    },
                    new Photo()
                    {
                        url = "https://picsum.photos/200/300"
                    }
                }
            }
        };

        [HttpGet("preference/{id}", Name = "GetPreference")]
        public SexualPreference GetPreference()
        {
            Random rng = new Random();
            return SexualPreferences[rng.Next(SexualPreferences.Length)];
        }

        [HttpDelete("preference/delete/{id}")]
        public void Delete(int id)
        {
            // to do
        }

        [HttpPost("preference/post/{id}")]
        public void Post()
        {
            // to do
        }

        [HttpPut("preference/put/{id}")]
        public void put(int id)
        {
            // to do
        }
    }
}
