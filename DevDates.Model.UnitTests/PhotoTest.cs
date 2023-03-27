using DevDates.Model.ViewModels;
using Xunit;

namespace DevDates.UnitTests
{
    public class PhotoTest
    {
        [Fact]
        public void TestPhotoUri()
        {
            // Arrange
            var photo = new Photo
            {
                Uri = "https://example.com/photo.jpg"
            };

            // Act
            var uri = photo.Uri;

            // Assert
            Assert.Equal("https://example.com/photo.jpg", uri);
        }
    }
}
