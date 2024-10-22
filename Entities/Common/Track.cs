using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Common
{
    internal class Track
    {
        public string Title {  get; set; }
        public string Time { get; set; }
        public Genre Genre { get; set; }
        //public Album Album { get; set; }

        public Track(string title, string time, Genre genre)
        {
            Title = title;
            Time = time;   
            Genre = genre;
            //Album = album;
        }

        

    }
}
