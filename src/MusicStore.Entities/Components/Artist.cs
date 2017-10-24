using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities
{
    public class Artist
    {
        public string Name { get; set; }
        public Artist()
        {
            Name = "No name";
        }
        public Artist(string name)
        {
            Name = name;
        }
    }
}
