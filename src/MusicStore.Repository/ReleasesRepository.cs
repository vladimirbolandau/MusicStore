using MusicStore.Entities;
using MusicStore.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Business
{
    public class ReleasesRepository
    {
        public void SaveToDb(List<AlbumDto> listOfReleases)
        {
            using (var ctx = new MusicStoreDBEntities())
            {
                foreach (var release in listOfReleases)
                {
                    var tempRelease = ctx.Releases
                        .Where(r => r.Album.Name == release.Name && r.Date == DateTime.Today)
                        .FirstOrDefault();

                    if (tempRelease == null)
                    {
                        var dbRelease = new Release()
                        {
                            Date = DateTime.Today,
                            Album = new Album()
                            {
                                Name = release.Name,
                                DateRelease = release.DateRelease,
                                AlbumArtUrl = release.AlbumArtUrl,
                                LinkToiTunes = release.AlbumLink
                            }
                        };
                        var tempGenre = ctx.Genres
                            .Where(r => r.Name == release.Genre.Name)
                            .FirstOrDefault();
                        if (tempGenre == null)
                        {
                            dbRelease.Album.Genre = new Genre() { Name = release.Genre.Name };
                        }
                        else
                        {
                            dbRelease.Album.GenreID = tempGenre.GenreID;
                        }

                        var tempArtist = ctx.Artists
                            .Where(a => a.Name == release.Artist.Name)
                            .FirstOrDefault();
                        if (tempArtist == null)
                        {
                            dbRelease.Album.Artist = new Artist() { Name = release.Artist.Name };
                        }
                        else
                        {
                            dbRelease.Album.ArtistID = tempArtist.ArtistID;
                        }

                        ctx.Releases.Add(dbRelease);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
