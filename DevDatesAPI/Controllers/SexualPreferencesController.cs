using DevDates.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using DevDates.DBModel.Data;
using DevDates.DBModel.Data.Models;

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
            var context = _context.Genders.Where(g => g.Id == id);

            _context.Remove(context);
            _context.SaveChanges();
        }

        [HttpPost("preference/post/{id}")]
        public void Post()
        {
            //var context = _context.Genders.Find(g => g.Id == id);
            // TODO
        }

        [HttpPut("preference/put/{id}")]
        public void put(int id, [FromBody] SexualPreference preference)
        {
            //var context = _context.Genders.Find(g => g.Id == id);
            //TODO
        }
    }
}