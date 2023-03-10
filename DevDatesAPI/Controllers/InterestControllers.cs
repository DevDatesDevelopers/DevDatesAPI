using DevDates.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestControllers
    {
        private readonly Interest[] Interests =
        {
            new Interest()
                    {
                        DisplayName = "Random Interest",
                        Photos = new Photo[]
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
                    new Interest()
                    {
                        DisplayName = "Random Interest 2",
                        Photos = new Photo[]
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
                    new Interest()
                    {
                        DisplayName = "Random Interest 3",
                        Photos = new Photo[]
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

        [HttpGet("interests/{id}", Name= "GetInterestsInfo")]
        public Interest GetInterestsInfo()
        {
            Random rng = new Random();
            return Interests[rng.Next(Interests.Length)];
        }
    }
}