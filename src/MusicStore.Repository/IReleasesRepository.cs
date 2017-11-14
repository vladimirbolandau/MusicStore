using MusicStore.Entities.Dto;
using System.Collections.Generic;

namespace MusicStore.Repository
{
    public interface IReleasesRepository
    {
        void Save(List<AlbumDto> listOfReleases);
    }
}
