using Moq;
using MusicStore.Entities.Dto;
using MusicStore.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace MusicStore.Business.Tests.Services
{
    [TestFixture]
    class NewReleasesServiceTests
    {
        private Mock<IReleasesProvider> _releasesProviderMock = new Mock<IReleasesProvider>();

        [Test]
        public void LoadTodayReleases_ReturnsListOfAlbumDto()
        {
            // Arrange
            var expectedResult = new List<AlbumDto>
            {
                new AlbumDto
                {
                    Name = "Name"
                }
            };
            _releasesProviderMock.Setup(m => m.GetTodayAlbums()).Returns(expectedResult);

            // Act
            var actualResult = new NewReleasesService(_releasesProviderMock.Object).LoadTodayReleases();

            // Assert
            // Assert.IsNotEmpty(actualResult);
            CollectionAssert.AreEquivalent(expectedResult, actualResult);
        }
    }
}
