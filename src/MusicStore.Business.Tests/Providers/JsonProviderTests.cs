using Moq;
using MusicStore.Business.Providers;
using MusicStore.Entities.Dto;
using MusicStore.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace MusicStore.Business.Tests.Providers
{
    [TestFixture]
    public class JsonProviderTests
    {
        //[Test]
        //public void SumOfTwoNumbers()
        //{
        //    Assert.IsTrue(2 + 2 == 4);

        //}

        private Mock<IReleasesRepository> _releasesRepositoryMock = new Mock<IReleasesRepository>();
        private Mock<ICacheRepository> _cacheRepositoryMock = new Mock<ICacheRepository>();

        

        //[Test]
        //public void GetTodayAlbums_ReturnsListOfAlbumDto()
        //{
        //    // Arrange
        //    _releasesRepositoryMock.Setup(m => m.Save(It.IsAny<List<AlbumDto>>()));
        //    _cacheRepositoryMock.Setup(m => m.DoesFileForTodayExists(It.IsAny<string>())).Returns(true);
        //    _cacheRepositoryMock.Setup(m => m.ClearCacheIn(It.IsAny<string>(), It.IsAny<string>()));
        //    var provider = new JsonProvider(_releasesRepositoryMock.Object, _cacheRepositoryMock.Object);


        //    // Act
        //    List<AlbumDto> expectedResult = provider.GetTodayAlbums();

        //    // Assert 
        //    Assert.IsNotEmpty(expectedResult);
        //}
    }
}
