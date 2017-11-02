using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities
{
    public class ArtistMS
    {
        public string Name { get; set; }
        public ArtistMS()
        {
            Name = "No name";
        }
        public ArtistMS(string name)
        {
            Name = name;
        }
    }
}
