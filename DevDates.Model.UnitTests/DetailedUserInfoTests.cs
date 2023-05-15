using DevDates.Model.ViewModels;
using Xunit;

namespace DevDates.Model.UnitTests
{
    public class DetailedUserInfoTests
    {
        [Fact]
        public void TestDetailedUserInfoProperties()
        {
            // Arrange
            var detailedUserInfo = new DetailedUserInfo
            {
                Bio = "Lorem ipsum dolor sit amet.",
                Interests = new Interest[]
                {
                    new Interest { DisplayName = "Hiking" },
                    new Interest { DisplayName = "Cooking" },
                }
            };

            // Assert
            Assert.Equal("Lorem ipsum dolor sit amet.", detailedUserInfo.Bio);
            Assert.Equal(2, detailedUserInfo.Interests.Length);
            Assert.Equal("Hiking", detailedUserInfo.Interests[0].DisplayName);
            Assert.Equal("Cooking", detailedUserInfo.Interests[1].DisplayName);
        }
    }
}
