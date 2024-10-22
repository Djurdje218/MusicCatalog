using MusicCatalog.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Patterns
{
    internal class MusicFactory
    {
        public static Artist CreateArtist(string name)
        {
            return new Artist(name);
        }

        public static Album CreateAlbum(string title, string releaseYear, Genre genre)
        {
            return new Album( title, releaseYear, genre );
        }

        public static Track CreateTrack(string title, string time, Genre genre, Album album)
        {
            return new Track(title, time, genre);
        }
    }
}
