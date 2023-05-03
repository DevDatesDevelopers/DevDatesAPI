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
        public ActionResult<List<Photo>> GetUserPhotos(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var photos = user.Resources
                .Where(r => r.ResourceUri.EndsWith(".jpg") || r.ResourceUri.EndsWith(".jpeg") || r.ResourceUri.EndsWith(".png") || r.ResourceUri.EndsWith(".gif"))
                .Select(r => new Photo
                {
                    Id = r.Id,
                    Url = r.ResourceUri,
                })
                .ToList();

            return Ok(photos);
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
