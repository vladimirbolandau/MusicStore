using MusicStore.Entities.Dto;
using System.Collections.Generic;

namespace MusicStore.Models
{
    public class NewReleasesModel
    {

        public string ArtistName { get; }

        public string AlbumName { get; }

        public string UrlToAlbumArt { get; }

        public string AlbumLink { get; }

        public NewReleasesModel() { }

        private NewReleasesModel(AlbumDto album)
        {
            ArtistName = album.Artist.Name;
            AlbumName = album.Name;
            UrlToAlbumArt = album.AlbumArtUrl;
            AlbumLink = album.AlbumLink;
        }

        public List<NewReleasesModel> GetReleasesList(List<AlbumDto> albumsList)
        {
            List<NewReleasesModel> ReleasesList = new List<NewReleasesModel>();
            foreach (var album in albumsList)
            {
                NewReleasesModel tempRelease = new NewReleasesModel(album);
                ReleasesList.Add(tempRelease);
            }
            return ReleasesList;
        }
    }
}