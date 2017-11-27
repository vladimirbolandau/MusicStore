using Moq;
using MusicStore.Entities.Dto;
using MusicStore.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MusicStore.Business.Tests.Controllers
{
    [TestFixture]
    class NewReleasesControllerTests
    {
        private Mock<IReleasesService> _releasesServiceMock = new Mock<IReleasesService>();

        [Test]
        public void Index_ReturnActionResult_ViewWithListOfNewReleasesModels()
        {
            // Arrange
            var expectedResult = new List<AlbumDto>
            {
                new AlbumDto
                {
                    Name = "Name"
                }
            };
            _releasesServiceMock.Setup(m => m.LoadTodayReleases()).Returns(expectedResult);

            // Act
            var actualResult = new NewReleasesModel().GetReleasesList(expectedResult);

            // Assert
            Assert.IsNotEmpty(actualResult);
        }
    }
}
