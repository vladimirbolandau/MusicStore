using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities
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
