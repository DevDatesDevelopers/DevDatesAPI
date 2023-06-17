using DevDates.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DevDates.DBModel.Data;
using System.Linq;
using DevDates.DBModel.Data.Models;

namespace DevDatesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikesController : ControllerBase
    {
        private DevDatesDbContext _context;
        public LikesController(DevDatesDbContext context)
        {
            _context = context;
        }

        [HttpGet("user/{userId}", Name = "GetUserLikes")]
        public Like[] GetUserLikes(string userId)
        {
            return _context.Likes.Where(l => l.LikerId == userId).ToArray();
        }

        [HttpPost("user/{userId}/like/{likedUserId}")]
        public IActionResult LikeUser(string userId, string likedUserId)
        {
            // Проверяваме дали вече има лайк от потребителя на likedUserId
            var existingLike = _context.Likes.FirstOrDefault(l => l.LikerId == userId && l.LikedId == likedUserId);

            if (existingLike != null)
            {
                return BadRequest("You have already liked this user");
            }

            // Създаваме нов лайк
            var newLike = new Like()
            {
                LikerId = userId,
                LikedId = likedUserId,
                Created = DateTime.UtcNow
            };
            _context.Likes.Add(newLike);
            _context.SaveChanges();

            return Ok("Success");
        }

        [HttpDelete("user/{userId}/like/{likedUserId}")]
        public IActionResult UnlikeUser(string userId, string likedUserId)
        {
            // Намираме лайк-а за да го изтрием
            var likeToDelete = _context.Likes.FirstOrDefault(l => l.LikerId == userId && l.LikedId == likedUserId);

            if (likeToDelete == null)
            {
                return BadRequest("You can't unlike");
            }

            // Трием
            _context.Likes.Remove(likeToDelete);
            _context.SaveChanges();

            return Ok("You successfully unlike");
        }
    }
}
