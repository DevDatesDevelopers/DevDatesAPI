using Microsoft.AspNetCore.Mvc;
using DevDatesAPI.Models;

namespace DevDatesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Names = new[]
    {
        "Geri Nikol", "Ivan Kalatchev", "Dqdo Sex", "Nasitu"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}", Name = "GetShortUserInfo")]
    public User Get()
    {
        var rng = new Random();
        return new User()
        {
            ShortInfo = new ShortUserInfo()
            {
                Name = Names[rng.Next(Names.Length)],
                Age = rng.Next(18, 65),
                Gender = "Random Gender"
            }
        };
    }

    [HttpGet("{id}", Name = "GetDetailedUserInfo")]
    public User GetDetailedInfo()
    {
        var rng = new Random();
        return new User()
        {
            DetailedInfo = new DetailedUserInfo()
            {
                ShortInfo = new ShortUserInfo()
                {
                    Name = Names[rng.Next(Names.Length)],
                    Age = rng.Next(18, 65),
                    Gender = "Random Gender"
                },
                Bio = "Random Bio"
            }
        };
    }
    
    [HttpGet("{id}", Name = "GetFullUserInfo")]
    public User GetFullInfo()
    {
        var rng = new Random();
        return new User()
        {
            DetailedInfo = new DetailedUserInfo()
            {
                ShortInfo = new ShortUserInfo()
                {
                    Name = Names[rng.Next(Names.Length)],
                    Age = rng.Next(18, 65),
                    Gender = "Random Gender"
                },
                Bio = "Random Bio"
            },
            ConnectedServices = new ConnectedService[]
            {
                new ConnectedService()
                {
                    Name = "Facebook",
                    Url = "https://www.facebook.com/"
                },
                new ConnectedService()
                {
                    Name = "Twitter",
                    Url = "https://twitter.com/"
                },
                new ConnectedService()
                {
                    Name = "Instagram",
                    Url = "https://www.instagram.com/"
                }
            }
        };
    }
}