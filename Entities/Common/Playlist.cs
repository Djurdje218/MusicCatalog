using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Common
{
    internal class Playlist
    {
       public string Name { get; set; }
       public List<Track> Tracks { get; set; } = new List<Track>();

        public Playlist(string name)
        {  
            Name = name;
        }

        public void AddTrack(Track track)
        {
            Tracks.Add(track);
        }

    }
}
