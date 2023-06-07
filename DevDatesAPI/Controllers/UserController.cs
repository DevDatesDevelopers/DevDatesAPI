using DevDates.DBModel.Data;
using DevDates.DBModel.Data.Models;
using Microsoft.AspNetCore.Mvc;
using DevDates.Model.ViewModels;
using Interest = DevDates.Model.ViewModels.ViewModelInterest;
using ViewModelUser = DevDates.Model.ViewModels.ViewModelUser;

namespace DevDatesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private DevDatesDbContext _context;

    public UserController(ILogger<UserController> logger, DevDatesDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("short/{id}", Name = "GetShortUserInfo")]
    public ViewModelUser Get(int id)
    {
        return _context.Users.Where(u => u.Id == id).Select(u => new DevDates.Model.ViewModels.ViewModelUser()
        {
            ShortInfo = new ShortUserInfo()
            {
                Age = DateTime.Now.Year - u.DateOfBirth.Value.Year,
                Gender = u.Gender.DisplayName,
                Name = u.Name,
                Photos = u.Resources.Where(r => r.ResourceType.DisplayName == "Photo").Select(r => new Photo()
                {
                    Uri = r.ResourceUri
                }).ToArray(),
                SexualPreferences = u.UsersPreferences.Select(up => new SexualPreference()
                {
                    DisplayName = up.Gender.DisplayName,
                    Photo = new Photo()
                    {
                        Uri = up.Gender.Resources.Where(r => r.ResourceType.DisplayName == "Photo").Select(r => r.ResourceUri).First()
                    }
                }).ToArray()
            }
        }).First();
    }

    [HttpGet("detailed/{id}", Name = "GetDetailedUserInfo")]
    public ViewModelUser GetDetailedInfo(int id)
    {
        return _context.Users.Where(u => u.Id == id).Select(u => new DevDates.Model.ViewModels.ViewModelUser()
        {
            ShortInfo = new ShortUserInfo()
            {
                Age = DateTime.Now.Year - u.DateOfBirth.Value.Year,
                Gender = u.Gender.DisplayName,
                Name = u.Name,
                Photos = u.Resources.Where(r => r.ResourceType.DisplayName == "Photo").Select(r => new Photo()
                {
                    Uri = r.ResourceUri
                }).ToArray(),
                SexualPreferences = u.UsersPreferences.Select(up => new SexualPreference()
                {
                    DisplayName = up.Gender.DisplayName,
                    Photo = new Photo()
                    {
                        Uri = up.Gender.Resources.Where(r => r.ResourceType.DisplayName == "Photo").Select(r => r.ResourceUri).First()
                    }
                }).ToArray()
            },
            DetailedInfo = new DetailedUserInfo()
            {
                Bio = u.Bio,
                Interests = u.Interests.Select(i => new Interest()
                {
                    DisplayName = i.DisplayName,
                    Photos = i.Resources.Where(r => r.ResourceType.DisplayName == "Photo").Select(r => new Photo()
                    {
                        Uri = r.ResourceUri
                    }).ToArray()
                }).ToArray(),
            }
        }).First();
    }
    
    [HttpGet("full/{id}", Name = "GetFullUserInfo")]
    public ViewModelUser GetFullInfo(int id)
    {
        return _context.Users.Where(u => u.Id == id).Select(u => new DevDates.Model.ViewModels.ViewModelUser()
        {
            ShortInfo = new ShortUserInfo()
            {
                Age = DateTime.Now.Year - u.DateOfBirth.Value.Year,
                Gender = u.Gender.DisplayName,
                Name = u.Name,
                Photos = u.Resources.Where(r => r.ResourceType.DisplayName == "Photo").Select(r => new Photo()
                {
                    Uri = r.ResourceUri
                }).ToArray(),
                SexualPreferences = u.UsersPreferences.Select(up => new SexualPreference()
                {
                    DisplayName = up.Gender.DisplayName,
                    Photo = new Photo()
                    {
                        Uri = up.Gender.Resources.Where(r => r.ResourceType.DisplayName == "Photo").Select(r => r.ResourceUri).First()
                    }
                }).ToArray()
            },
            DetailedInfo = new DetailedUserInfo()
            {
                Bio = u.Bio,
                Interests = u.Interests.Select(i => new Interest()
                {
                    DisplayName = i.DisplayName,
                    Photos = i.Resources.Where(r => r.ResourceType.DisplayName == "Photo").Select(r => new Photo()
                    {
                        Uri = r.ResourceUri
                    }).ToArray()
                }).ToArray(),
            },
            ConnectedServices = u.Resources.Where(r => r.ResourceType.DisplayName == "ConnectedService").Select(r => new ConnectedService()
            {
                Name = r.ResourceType.DisplayName,
                Url = r.ResourceUri
            }).ToArray()
        }).First();
    }
    
    [HttpPost("update/{id}", Name = "UpdateUserInfo")]
    public void UpdateUser(int id,[FromBody] ViewModelUser user)
    {
        var dbUser = _context.Users.First(u => u.Id == id);
        dbUser.Name = user.ShortInfo.Name;
        dbUser.Bio = user.DetailedInfo.Bio;
        _context.SaveChanges();
    }
    
    [HttpPost("addPhoto/{id}", Name = "AddPhoto")]
    public void AddPhoto(int id,[FromBody] Photo photo)
    {
        var dbUser = _context.Users.First(u => u.Id == id);
        var photoResource = new Resource()
        {
            ResourceUri = photo.Uri,
            ResourceType = _context.ResourcesTypes.First(rt => rt.DisplayName == "Photo")
        };
        dbUser.Resources.Add(photoResource);
        _context.SaveChanges();
    }
    
    
}
