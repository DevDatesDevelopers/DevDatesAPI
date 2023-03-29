using DevDates.Model.ViewModels;
using Xunit;

namespace DevDates.Model.UnitTests
{
    public class InterestTests
    {
        [Fact]
        public void TestInterestProperties()
        {
            // Arrange
            var interest = new Interest
            {
                DisplayName = "Hiking",
                Photos = new Photo[]
                {
                    new Photo { Uri = "https://example.com/photo.jpg" }
                }
            };

            // Assert
            Assert.Equal("Hiking", interest.DisplayName);
            Assert.Single(interest.Photos);
            Assert.Equal("https://example.com/photo.jpg", interest.Photos[0].Uri);
        }
    }
}
