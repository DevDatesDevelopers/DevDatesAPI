using DevDates.DBModel.Data.Models;
using DevDates.DBModel.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using DevDates.Model.ViewModels;

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
        public ActionResult<List<Photo>> GetUserPhotos(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return NotFound();
            }

            var photos = user.Resources
                .Where(r => r.ResourceUri != null && (r.ResourceUri.EndsWith(".jpg") || r.ResourceUri.EndsWith(".jpeg") || r.ResourceUri.EndsWith(".png") || r.ResourceUri.EndsWith(".gif")))
                .Select(r => new Photo
                {
                    Uri = r.ResourceUri ?? string.Empty, 
                })
                .ToList();

            return Ok(photos);
        }


        [HttpDelete("photos/delete/{id}")]
        public ActionResult Delete(int id)
        {
            var resource = _context.Resources.FirstOrDefault(r => r.Id == id);

            if (resource == null)
            {
                return NotFound();
            }

            _context.Resources.Remove(resource);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("photos/post")]
        public ActionResult<Photo> Post([FromBody] Resource resource)
        {
            _context.Resources.Add(resource);
            _context.SaveChanges();

            var photo = new Photo
            {
                Uri = resource.ResourceUri ?? string.Empty
            };

            return CreatedAtRoute("GetUserPhotos", new { userId = resource.Id }, photo);
        }

        [HttpPut("photos/put/{id}")]
        public ActionResult Put(int id, [FromBody] Resource resource)
        {
            var existingResource = _context.Resources.FirstOrDefault(r => r.Id == id);

            if (existingResource == null)
            {
                return NotFound();
            }

            existingResource.ResourceUri = resource.ResourceUri;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
