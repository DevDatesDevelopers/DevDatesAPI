using DevDates.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using DevDates.DBModel.Data;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SexualPreferencesController
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
                DisplayName = g.DisplayName
            }).ToArray();
        }

        [HttpGet("preference/{id}", Name = "GetPreference")]
        public SexualPreference GetPreference(int id)
        {
            return _context.Genders.Where(g => g.Id == id).Select(g => new SexualPreference()
            {
                DisplayName = g.DisplayName
            }).ToArray()[0];
        }

        [HttpDelete("preference/delete/{id}")]
        public void Delete(int id)
        {
            var preference = _context.Genders.FirstOrDefault(p => p.Id == id);
            if (preference != null)
            {
                _context.Genders.Remove(preference);
                _context.SaveChanges();
            }
        }

        [HttpPost("preference/post/{id}")]
        public void Post([FromBody] SexualPreference preference)
        {
            if (preference != null)
            {
                var newPreference = new Gender { DisplayName = preference.DisplayName };
                _context.Genders.Add(newPreference);
                _context.SaveChanges();
            }
        }

        [HttpPut("preference/put/{id}")]
        public void Put(int id, [FromBody] SexualPreference preference)
        {
            var existingPreference = _context.Genders.FirstOrDefault(p => p.Id == id);
            if (existingPreference != null && preference != null)
            {
                existingPreference.DisplayName = preference.DisplayName;
                _context.SaveChanges();
            }
        }
    }
}
