﻿using MusicStore.Entities.DbModels;
using MusicStore.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Repository
{
    public class ReleasesRepository : IReleasesRepository
    {
        public void Save(List<AlbumDto> listOfReleases)
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
                        var dbRelease = new Release() { Date = DateTime.Today };

                        var tempArtist = ctx.Artists
                                .Where(a => a.Name == release.Artist.Name)
                                .FirstOrDefault();

                        if (tempArtist == null)
                        {
                            dbRelease.Album = new Album()
                            {
                                Name = release.Name,
                                DateRelease = release.DateRelease,
                                AlbumArtUrl = release.AlbumArtUrl,
                                LinkToiTunes = release.AlbumLink
                            };

                            var tempGenre = ctx.Genres
                            .Where(r => r.Name == release.Genre.Name)
                            .FirstOrDefault();
                            if (tempGenre == null)
                            {
                                dbRelease.Album.Genre = new Entities.DbModels.Genre() { Name = release.Genre.Name };
                            }
                            else
                            {
                                dbRelease.Album.GenreID = tempGenre.GenreID;
                            }

                            dbRelease.Album.Artist = new Artist() { Name = release.Artist.Name };
                        }
                        else
                        {
                            var tempAlbum = ctx.Albums
                            .Where(a => a.Name == release.Name
                                && a.ArtistID == tempArtist.ArtistID)
                            .FirstOrDefault();
                            if (tempAlbum == null)
                            {
                                dbRelease.Album = new Album()
                                {
                                    Name = release.Name,
                                    DateRelease = release.DateRelease,
                                    AlbumArtUrl = release.AlbumArtUrl,
                                    LinkToiTunes = release.AlbumLink
                                };

                                var tempGenre = ctx.Genres
                                .Where(r => r.Name == release.Genre.Name)
                                .FirstOrDefault();
                                if (tempGenre == null)
                                {
                                    dbRelease.Album.Genre = new Entities.DbModels.Genre() { Name = release.Genre.Name };
                                }
                                else
                                {
                                    dbRelease.Album.GenreID = tempGenre.GenreID;
                                }

                                dbRelease.Album.ArtistID = tempArtist.ArtistID;
                            }
                            else
                            {
                                dbRelease.AlbumID = tempAlbum.AlbumID;
                            }
                        }
                        ctx.Releases.Add(dbRelease);
                        ctx.SaveChanges();
                    }
                }
            }
        }
    }
}
