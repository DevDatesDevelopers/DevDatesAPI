/*using DevDates.DBModel;
using DevDates.DBModel;
using DevDates.DBModel.Data;
using DevDates.DBModel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System.Reflection;
using Xunit;

namespace DevDates.DBModel.UnitTests
{
    public class UserTests
    {
        [Fact]
        public void TestAddUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DevDatesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new DevDatesDbContext(options);

            var user = new User
            {
                Name = "John Smith",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = Gender.Male,
                Bio = "Lorem ipsum dolor sit amet.",
                Interests = new List<Interest>
                {
                    new Interest { DisplayName = "Hiking" },
                    new Interest { DisplayName = "Cooking" },
                },
                UsersPreferences = new List<UserSexualPreference>
                {
                    new UserSexualPreference { Gender = Gender.Female }
                },
                Resources = new List<Resource>
                {
                    new Resource { ResourceTypeId = 1, ResourceUri = "https://example.com/photo.jpg" },
                    new Resource { ResourceTypeId = 2, ResourceUri = "https://example.com/twitter" },
                }
            };

            // Act
            context.Users.Add(user);
            context.SaveChanges();

            // Assert
            Assert.Equal(1, context.Users.Count());
        }

        [Fact]
        public void TestGetUserById()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DevDatesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new DevDatesDbContext(options);

            var user = new User
            {
                Name = "John Smith",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = Gender.Male,
                Bio = "Lorem ipsum dolor sit amet.",
                Interests = new List<Interest>
                {
                    new Interest { DisplayName = "Hiking" },
                    new Interest { DisplayName = "Cooking" },
                },
                UsersPreferences = new List<UserSexualPreference>
                {
                    new UserSexualPreference { Gender = Gender.Female }
                },
                Resources = new List<Resource>
                {
                    new Resource { ResourceTypeId = 1, ResourceUri = "https://example.com/photo.jpg" },
                    new Resource { ResourceTypeId = 2, ResourceUri = "https://example.com/twitter" },
                }
            };

            context.Users.Add(user);
            context.SaveChanges();

            // Act
            var userService = new UserService(context);
            var retrievedUser = userService.GetUserById(user.Id);
            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Name, retrievedUser.Name);
            Assert.Equal(user.DateOfBirth, retrievedUser.DateOfBirth);
            Assert.Equal(user.Gender, retrievedUser.Gender);
            Assert.Equal(user.Bio, retrievedUser.Bio);
            Assert.Equal(user.Interests.Count, retrievedUser.Interests.Count);
            Assert.Equal(user.UsersPreferences.Count, retrievedUser.UsersPreferences.Count);
            Assert.Equal(user.Resources.Count, retrievedUser.Resources.Count);
            for (int i = 0; i < user.Interests.Count; i++)
            {
                Assert.Equal(user.Interests[i].DisplayName, retrievedUser.Interests[i].DisplayName);
            }
            for (int i = 0; i < user.UsersPreferences.Count; i++)
            {
                Assert.Equal(user.UsersPreferences[i].Gender, retrievedUser.UsersPreferences[i].Gender);
            }
            for (int i = 0; i < user.Resources.Count; i++)
            {
                Assert.Equal(user.Resources[i].ResourceTypeId, retrievedUser.Resources[i].ResourceTypeId);
                Assert.Equal(user.Resources[i].ResourceUri, retrievedUser.Resources[i].ResourceUri);
            }
        }
    }
}
*/