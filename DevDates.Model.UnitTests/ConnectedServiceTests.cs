using DevDates.Model.ViewModels;
using Xunit;

namespace DevDates.Model.UnitTests
{
    public class ConnectedServiceTests
    {
        [Fact]
        public void TestConnectedServiceProperties()
        {
            // Arrange
            var connectedService = new ConnectedService
            {
                Name = "Twitter",
                Url = "https://twitter.com/example"
            };

            // Assert
            Assert.Equal("Twitter", connectedService.Name);
            Assert.Equal("https://twitter.com/example", connectedService.Url);
        }
    }
}
