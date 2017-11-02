using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Entities
{
    public class GenreMS
    {
        public string Name { get; set; }
        public GenreMS()
        {
            Name = "No genre";
        }
        public GenreMS(string name)
        {
            Name = name;
        }
    }
}
