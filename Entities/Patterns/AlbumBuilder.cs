using MusicCatalog.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Patterns
{
    internal class AlbumBuilder
    {
        private string title;
        private string releaseYear;
        private Genre genre;
        private List<Track> tracks = new List<Track>();

        
        public AlbumBuilder SetTitle(string Title)
        {
            title = Title;
            return this;
        }

        public AlbumBuilder SetReleaseYear(string ReleaseYear)
        {
            releaseYear = ReleaseYear;
            return this;
        }

        public AlbumBuilder SetGenre(Genre Genre)
        {
            genre = Genre;
            return this;
        }

        public AlbumBuilder AddTrack(Track Track)
        {
            tracks.Add(Track);
            return this;
        }

     

        public Album Build()
        {
            Album album = new Album(title, releaseYear, genre);
            foreach(var track in tracks)
            {
                album.AddTrack(track);
            }
            return album;
        }
    }

   
}
