using Microsoft.AspNetCore.Mvc;
using DevDatesAPI.Models;

namespace DevDatesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static readonly string[] Names = new[]
    {
        "Geri Nikol", "Ivan Kalatchev", "Dqdo Sex", "Nasitu"
    };

    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
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
                Gender = "Random Gender",
                SexualPreferences = new []
                {
                    new SexualPreference()
                    {
                        DisplayName = "Men"
                    },
                    new SexualPreference()
                    {
                        DisplayName = "Women"
                    }
                },
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
                    Gender = "Random Gender",
                    SexualPreferences = new []
                    {
                        new SexualPreference()
                        {
                            DisplayName = "Men"
                        },
                        new SexualPreference()
                        {
                            DisplayName = "Women"
                        }
                    },
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
                Bio = "Random Bio",
                Interests = new Interest[]
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
                }
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
                    Gender = "Random Gender",
                    SexualPreferences = new []
                    {
                        new SexualPreference()
                        {
                            DisplayName = "Men"
                        },
                        new SexualPreference()
                        {
                            DisplayName = "Women"
                        }
                    },
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
                Bio = "Random Bio",
                Interests = new Interest[]
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
                }
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
