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

        public void RemoveTrack(Track track)
        {
            Tracks.Remove(track);
        }

        public void DisplayTracks()
        {
            if (Tracks.Count == 0)
            {
                Console.WriteLine($"Playlist '{Name}' has no tracks.");
            }
            else
            {
                Console.WriteLine($"Tracks in playlist '{Name}':");
                foreach (var track in Tracks)
                {
                    Console.WriteLine($"  - {track.Title}  (Genre: {track.Genre.genreName})");
                }
            }
        }

        public void AddAlbum(Album album)
        {
            foreach(var track in album.AlbumTracks)
            {
                this.Tracks.Add(track);
            }
        }
    }
}