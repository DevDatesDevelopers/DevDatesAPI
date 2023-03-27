using DevDates.Model.ViewModels;
using System;
using Xunit;

namespace DevDates.Model.UnitTests
{
    public class ShortUserInfoTests
    {
        [Fact]
        public void TestShortUserInfoProperties()
        {
            // Arrange
            var shortUserInfo = new ShortUserInfo
            {
                Name = "John Smith",
                Age = 30,
                Gender = "Male",
                SexualPreferences = new SexualPreference[]
                {
                    new SexualPreference { DisplayName = "Female" }
                },
                Photos = new Photo[]
                {
                    new Photo { Uri = "https://example.com/photo.jpg" }
                }
            };

            // Assert
            Assert.Equal("John Smith", shortUserInfo.Name);
            Assert.Equal(30, shortUserInfo.Age);
            Assert.Equal("Male", shortUserInfo.Gender);
            Assert.Single(shortUserInfo.SexualPreferences);
            Assert.Equal("Female", shortUserInfo.SexualPreferences[0].DisplayName);
            Assert.Single(shortUserInfo.Photos);
            Assert.Equal("https://example.com/photo.jpg", shortUserInfo.Photos[0].Uri);
        }
    }
}
