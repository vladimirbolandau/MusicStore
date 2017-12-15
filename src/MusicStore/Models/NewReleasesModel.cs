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

        public NewReleasesModel(AlbumDto album)
        {
            ArtistName = album.Artist.Name;
            AlbumName = album.Name;
            UrlToAlbumArt = album.AlbumArtUrl;
            AlbumLink = album.AlbumLink;
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