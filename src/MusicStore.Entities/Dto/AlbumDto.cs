using System;

namespace MusicStore.Entities.Dto
{
    public class AlbumDto
    {
        public string Name { get; set; }

        public ArtistDto Artist { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime DateRelease { get; set; }

        public string AlbumLink { get; set; }

        public string AlbumArtUrl { get; set; }

        public AlbumDto()
        {
            Name = "No Album";
            Artist = new ArtistDto();
            Genre = new GenreDto();
            DateRelease = new DateTime();
            AlbumLink = "No Link";
            AlbumArtUrl = "No URL";
        }

        public AlbumDto(string name, string artistName, string genreName,
            string dateRelease, string albumLink, string artLink)
        {
            Name = name;
            Artist = new ArtistDto(artistName);
            Genre = new GenreDto(genreName);
            try
            {
                DateRelease = DateTime.ParseExact(dateRelease, "ddd, dd MMM yyyy HH:mm:ss zzz",
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                try
                {
                    DateRelease = DateTime.ParseExact(dateRelease, "ddd, d MMM yyyy HH:mm:ss zzz",
                        System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    try
                    {
                        DateRelease = DateTime.ParseExact(dateRelease, "yyyy-MM-dd",
                            System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            DateRelease = DateTime.ParseExact(dateRelease, "yyyy-MM",
                                System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                DateRelease = DateTime.ParseExact(dateRelease, "yyyy",
                                    System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                DateRelease = new DateTime();
                            }
                        }
                    }
                }
            }
            
            AlbumLink = albumLink;
            AlbumArtUrl = artLink;
        }
    }
}