using MusicStore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class NewReleasesModel
    {

        public string ArtistName { get; }

        public string AlbumName { get; }

        public string UrlToAlbumArt { get; }

        public string AlbumLink { get; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate = DateTime.Today;

        public NewReleasesModel() { }

        private NewReleasesModel(AlbumDto album)
        {
            ArtistName = album.Artist.Name;
            AlbumName = album.Name;
            UrlToAlbumArt = album.AlbumArtUrl;
            AlbumLink = album.AlbumLink;
        }

        public List<NewReleasesModel> ToViewModel(List<AlbumDto> albumsList)
        {
            List<NewReleasesModel> ReleasesList = new List<NewReleasesModel>();
            foreach (var album in albumsList)
            {
                NewReleasesModel tempRelease = new NewReleasesModel(album);
                ReleasesList.Add(tempRelease);
            }
            return ReleasesList;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is NewReleasesModel))
            {
                return false;
            }

            return ArtistName == ((NewReleasesModel)obj).ArtistName;
        }
    }
}