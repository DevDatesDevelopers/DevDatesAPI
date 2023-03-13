using DevDates.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SexualPreferenceController
    {
        private readonly SexualPreference[] SexualPreference =
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
            return SexualPreference[rng.Next(SexualPreference.Length)];
        }
    }
}
