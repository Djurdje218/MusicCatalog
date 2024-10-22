using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Common
{
    internal class Album
    {
        public string Title { get; set; }
        public string ReleaseYear {  get; set; }
        public Genre Genre { get; set; }
        public List<Track> AlbumTracks { get; set; } = new List<Track>();   

        public Album(string title, string releaseYear, Genre genre)
        {
            Title = title;
            ReleaseYear = releaseYear;
            Genre = genre;
        }

        public void AddTrack(Track track)
        {
            AlbumTracks.Add(track);
        }
    }
}
