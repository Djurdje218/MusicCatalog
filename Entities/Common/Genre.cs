using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Common
{
    internal class Genre
    {
        public string genreName { get; set; }

        public Genre(string name)
        {
            genreName = name;
        }
    }
}
