using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities
{
    public class Genre
    {
        public string Name { get; set; }
        public Genre()
        {
            Name = "No genre";
        }
        public Genre(string name)
        {
            Name = name;
        }
    }
}
