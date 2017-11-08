namespace MusicStore.Entities.Dto
{
    public class ArtistDto
    {
        public string Name { get; set; }

        public ArtistDto()
        {
            Name = "No name";
        }

        public ArtistDto(string name)
        {
            Name = name;
        }
    }
}
