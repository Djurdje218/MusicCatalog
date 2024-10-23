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
        public  Artist CreateArtist(string name)
        {
            return new Artist(name);
        }

        public  Album CreateAlbum(string title, string releaseYear, Genre genre)
        {
            return new Album( title, releaseYear, genre );
        }

        public  Track CreateTrack(string title, string time, Genre genre, Album album)
        {
            return new Track(title, time, genre);
        }

        public Genre CreateGenre(string name)
        {
            return new Genre(name);
        }

        public Playlist CreatePlaylist(string name)
        {
            return new Playlist(name);
        }
    }
}
