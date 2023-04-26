using DevDates.Model.ViewModels;
using DevDates.DBModel.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {
        private DevDatesDbContext _context;
        public PhotoController(DevDatesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}/photos", Name = "GetUserPhotos")]
        public ActionResult<UserPhotosViewModel> GetUserPhotos(int userId)
        {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        var viewModel = new UserPhotosViewModel
        {
            UserId = userId,
            Photos = user.Photos.Select(p => new PhotoViewModel
            {
                Id = p.Id,
                Url = p.Url,
                Description = p.Description
            }).ToList()
        };

        return Ok(viewModel);
        }

        [HttpDelete("photos/delete/{id}")]
        public void Delete(int id)
        {
            // TODO
        }

        [HttpPost("photos/post")]
        public void Post()
        {
            // TODO
        }

        [HttpPut("photos/put/{id}")]
        public void put(int id)
        {
            // TODO
        }
    }
}


