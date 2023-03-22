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
            // TODO
        }

        [HttpPost("preference/post/{id}")]
        public void Post()
        {
            // TODO
        }

        [HttpPut("preference/put/{id}")]
        public void put(int id)
        {
            // TODO
        }
    }
}
