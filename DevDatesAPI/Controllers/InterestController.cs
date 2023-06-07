using DevDates.DBModel.Data;
using DevDates.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterestController : Controller
    {
        private DevDatesDbContext _context;
        public InterestController(DevDatesDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("interests", Name = "GetAllInterests")]
        public IActionResult GetAllInterests()
        {
            return Ok(_context.Interests.Select(i => new ViewModelInterest()
            {
                DisplayName = i.DisplayName,
                Photos = i.Resources.Select(r => new Photo()
                {
                    Uri = r.ResourceUri
                })
            }).ToArray());
        }
        
        
        [HttpGet("interests/{id}", Name= "GetInterestsInfo")]
        public ViewModelInterest GetInterestsInfo(int id)
        {
            return _context.Interests.Where(i => i.Id == id).Select(i => new ViewModelInterest()
            {
                DisplayName = i.DisplayName,
                Photos = i.Resources.Select(r => new Photo()
                {
                    Uri = r.ResourceUri
                }).ToArray()
            }).ToArray()[0];
        }
    }
}