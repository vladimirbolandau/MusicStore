using Moq;
using MusicStore.Controllers;
using MusicStore.Entities.Dto;
using MusicStore.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
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
            var albumDtos = new List<AlbumDto>
            {
                new AlbumDto
                {
                    Name = "Name"
                }
            };
            _releasesServiceMock.Setup(m => m.LoadTodayReleases()).Returns(albumDtos);

            var expectedResult = new NewReleasesModel().ToViewModel(albumDtos);

            // Act
            var actualResult = new NewReleasesController(_releasesServiceMock.Object).Index();

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, actualResult.Model as List<NewReleasesModel>);
            //Assert.NotNull(actualResult.Model);
        }
    }
}
