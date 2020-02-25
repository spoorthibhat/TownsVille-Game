using NUnit.Framework;

using Game.Models;
using Game.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    [TestFixture]
    class ImageModelTest
    {
        [Test]
        public void ImageModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new Image();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }
    }
}
