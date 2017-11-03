using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities
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
