namespace MusicStore.Entities.Dto
{
    public class GenreDto
    {
        public string Name { get; set; }

        public GenreDto()
        {
            Name = "No genre";
        }

        public GenreDto(string name)
        {
            Name = name;
        }
    }
}
