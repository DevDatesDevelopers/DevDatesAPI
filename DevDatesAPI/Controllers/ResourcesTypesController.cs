using DevDates.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using DevDates.DBModel.Data;
using DevDates.DBModel.Data.Models;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourcesTypeController : ControllerBase
    {
        private DevDatesDbContext _context;
        public ResourcesTypeController(DevDatesDbContext context)
        {
            _context = context;
        }

        [HttpGet("resourcetypes", Name = "GetAllResourceTypes")]
        public ResourceType[] GetAllResourceTypes()
        {
            return _context.ResourceTypes.Select(rt => new ResourceType()
            {
                Id = rt.Id,
                DisplayName = rt.DisplayName,
                Created = rt.Created,
                Modified = rt.Modified,
                ModifiedBy = rt.ModifiedBy,
                Resources = rt.Resources
            }).ToArray();
        }

        [HttpGet("resourcetype/{id}", Name = "GetResourceType")]
        public ResourceType GetResourceType(int id)
        {
            return _context.ResourceTypes.Where(rt => rt.Id == id).Select(rt => new ResourceType()
            {
                Id = rt.Id,
                DisplayName = rt.DisplayName,
                Created = rt.Created,
                Modified = rt.Modified,
                ModifiedBy = rt.ModifiedBy,
                Resources = rt.Resources
            }).ToArray()[0];
        }

        [HttpDelete("resourcetype/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var resourceType = _context.ResourceTypes.FirstOrDefault(rt => rt.Id == id);

            if (resourceType == null)
            {
                return NotFound();
            }

            _context.Remove(resourceType);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("resourcetype/post")]
        public IActionResult Post([FromBody] ResourceType resourceType)
        {
            if (resourceType == null)
            {
                return BadRequest();
            }

            var rt = new ResourceType
            {
                DisplayName = resourceType.DisplayName,
                Created = resourceType.Created,
                Modified = resourceType.Modified,
                ModifiedBy = resourceType.ModifiedBy,
                Resources = resourceType.Resources
            };

            _context.ResourceTypes.Add(rt);
            _context.SaveChanges();

            return CreatedAtRoute("GetResourceType", new { id = rt.Id }, resourceType);
        }

        [HttpPut("resourcetype/put/{id}")]
        public IActionResult Put(int id, [FromBody] ResourceType resourceType)
        {
            if (resourceType == null || id != resourceType.Id)
            {
                return BadRequest();
            }

            var rt = _context.ResourceTypes.FirstOrDefault(rt => rt.Id == id);

            if (rt == null)
            {
                return NotFound();
            }

            rt.DisplayName = resourceType.DisplayName;
            rt.Created = resourceType.Created;
            rt.Modified = resourceType.Modified;
            rt.ModifiedBy = resourceType.ModifiedBy;
            rt.Resources = resourceType.Resources;

            _context.ResourceTypes.Update(rt);
            _context.SaveChanges();

            return NoContent();
        }
        public void Delete()
        {
            // TODO
        }

        [HttpPost("resourcetype/put/{id}")]
        public void Post()
        {
            // TODO
        }

        [HttpPut("resourcetype/put/{id}")]
        public void put(int id)
        {
            // TODO
        }
    }
}
