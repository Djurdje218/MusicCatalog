using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Common
{
    internal class Artist
    {
        public string Name { get; set; }
        public List<Album> Albums = new List<Album>();

        public Artist( string name )
        {
            this.Name = name;
        }

        public void AddAlbum(Album album)
        {
            Albums.Add( album );
        }
    }
}
