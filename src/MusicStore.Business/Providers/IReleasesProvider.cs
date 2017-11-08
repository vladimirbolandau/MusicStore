using MusicStore.Entities.Dto;
using System.Collections.Generic;

namespace MusicStore.Repository
{
    public interface IReleasesProvider
    {
        List<AlbumDto> GetTodayAlbums();
    }
}
