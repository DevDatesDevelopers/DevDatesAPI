using DevDates.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DevDates.DBModel.Data;
using System.Linq;

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
        public Like[] GetUserLikes(int userId)
        {
            return _context.Likes.Where(l => l.UserId == userId).ToArray();
        }

        [HttpPost("user/{userId}/like/{likedUserId}")]
        public IActionResult LikeUser(int userId, int likedUserId)
        {
            // Проверяваме дали вече има лайк от потребителя на likedUserId
            var existingLike = _context.Likes.FirstOrDefault(l => l.UserId == userId && l.LikedUserId == likedUserId);

            if (existingLike != null)
            {
                return BadRequest("You have already liked this user");
            }

            // Създаваме нов лайк
            var newLike = new Like()
            {
                UserId = userId,
                LikedUserId = likedUserId
            };
            _context.Likes.Add(newLike);
            _context.SaveChanges();

            return Ok("Success");
        }

        [HttpDelete("user/{userId}/like/{likedUserId}")]
        public IActionResult UnlikeUser(int userId, int likedUserId)
        {
            // Намираме лайка за да го изтрием
            var likeToDelete = _context.Likes.FirstOrDefault(l => l.UserId == userId && l.LikedUserId == likedUserId);

            if (likeToDelete == null)
            {
                return BadRequest("You can't unlike");
            }

            // Изтриваме лайка
            _context.Likes.Remove(likeToDelete);
            _context.SaveChanges();

            return Ok("You successfully unlike");
        }
    }
}