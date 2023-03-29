using DevDates.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using DevDates.DBModel.Data;
using DevDates.DBModel.Data.Models;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SexualPreferencesController : ControllerBase
    {
        private DevDatesDbContext _context;
        public SexualPreferencesController(DevDatesDbContext context)
        {
            _context = context;
        }
        


        [HttpGet("preferences", Name = "GetAllPreferences")]
        public SexualPreference[] GetAllPreferences()
        {
            return _context.Genders.Select(g => new SexualPreference()
            {
                Id = g.Id,
                DisplayName = g.DisplayName
            }).ToArray();
        }



        [HttpGet("preference/{id}", Name = "GetPreference")]
        public SexualPreference GetPreference(int id)
        {
            return _context.Genders.Where(g => g.Id == id).Select(g => new SexualPreference()
            {
                Id = g.Id,
                DisplayName = g.DisplayName
            }).ToArray()[0];
        }



        [HttpDelete("preference/delete/{id}")]
        public IActionResult Delete(int id)
        {
            /*
            var context = _context.Genders.Where(g => g.Id == id);

            _context.Remove(context);
            _context.SaveChanges();
            */

            var context = _context.Genders.FirstOrDefault(g => g.Id == id);

            if (context == null)
            {
                return NotFound();
            }

            _context.Remove(context);
            _context.SaveChanges();

            return NoContent();
        }



        [HttpPost("preference/post/{id}")]
        public IActionResult Post([FromBody] SexualPreference preference)
        {
            //var context = _context.Genders.Find(g => g.Id == id);

            if (preference == null)
            {
                return BadRequest();
            }

            var gender = new Gender
            {
                DisplayName = preference.DisplayName
            };

            _context.Genders.Add(gender);
            _context.SaveChanges();

            return CreatedAtRoute("GetPreference", new { id = gender.Id }, preference);
        }



        [HttpPut("preference/put/{id}")]
        public IActionResult put(int id, [FromBody] SexualPreference preference)
        {
            //var context = _context.Genders.Find(g => g.Id == id);
            
            if (preference == null || id != preference.Id)
            {
                return BadRequest();
            }

            var gender = _context.Genders.FirstOrDefault(g => g.Id == id);

            if (gender == null)
            {
                return NotFound();
            }

            gender.DisplayName = preference.DisplayName;

            _context.Genders.Update(gender);
            _context.SaveChanges();

            return NoContent();
        }
    }
}