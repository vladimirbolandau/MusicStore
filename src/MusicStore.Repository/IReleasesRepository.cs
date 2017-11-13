using MusicStore.Entities.Dto;
using System.Collections.Generic;

namespace MusicStore.Repository
{
    interface IReleasesRepository
    {
        void Save(List<AlbumDto> listOfReleases);
    }
}
