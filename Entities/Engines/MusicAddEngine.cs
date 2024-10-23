using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Engines
{
    using MusicCatalog.Entities.Common;
    using System;
    using System.Collections.Generic;
    using MusicCatalog.Entities.Patterns;

    class MusicAddEngine
    {
        private List<Artist> artists;
        private List<Genre> genres;
        private List<Playlist> playlists;
        private MusicFactory factory;
        private AlbumBuilder albumBuilder;

        public MusicAddEngine(List<Artist> artists, List<Genre> genres, List<Playlist> playlist)
        {
            this.artists = artists;
            this.genres = genres;
            this.playlists = playlist;
            this.factory = new MusicFactory();
            this.albumBuilder = new AlbumBuilder();
        }

        public void AddNewArtist()
        {
            Console.Write("Enter artist name: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (artists.Exists(a => a.Name == name))
                {
                    Console.WriteLine($"Artist '{name}' already exists.");
                }
                else
                {
                    artists.Add(new Artist(name));
                    Console.WriteLine($"Artist '{name}' added successfully.");
                }
            }
            else
            {
                Console.WriteLine("Artist name cannot be empty.");
            }
        }
        public void AddNewPlaylist()
        {
            Console.Write("Enter Playlist name: ");
            string name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (playlists.Exists(p => p.Name == name))
                {
                    Console.WriteLine($"Playlist '{name}' already exists.");
                }
                else
                {
                    playlists.Add(new Playlist(name));
                    Console.WriteLine($"Playlist '{name}' added successfully.");
                }
            }
            else
            {
                Console.WriteLine("Playlist name cannot be empty.");
            }
        }
        public void AddNewAlbum()
        {
            Console.Write("Enter artist name: ");
            string artistName = Console.ReadLine();
            var artist = artists.Find(a => a.Name == artistName);
            if (artist == null)
            {
                Console.WriteLine($"Artist '{artistName}' not found.");
                return;
            }

            Console.Write("Enter album title: ");
            string albumTitle = Console.ReadLine();

            Console.Write("Enter release year: ");
            string releaseYear = Console.ReadLine();

            Genre genre = ChooseGenre();

            if (genre != null)
            {
                var album = new Album(albumTitle, releaseYear, genre);
                artist.Albums.Add(album);
                Console.WriteLine($"Album '{albumTitle}' added to artist '{artistName}'.");
            }
        }

        // Method add a new track
        public void AddNewTrack()
        {
            Console.Write("Enter artist name: ");
            string artistName = Console.ReadLine();
            var artist = artists.Find(a => a.Name == artistName);
            if (artist == null)
            {
                Console.WriteLine($"Artist '{artistName}' not found.");
                Console.WriteLine("Add artist and Album first, then add track");
                return;
            }

            Console.Write("Enter album title: ");
            string albumTitle = Console.ReadLine();
            var album = artist.Albums.Find(a => a.Title == albumTitle);
            if (album == null)
            {
                Console.WriteLine($"Album '{albumTitle}' not found for artist '{artistName}'.");
                Console.WriteLine("Add Album first, then add Track");
                return;
            }

            Console.Write("Enter track title: ");
            string trackTitle = Console.ReadLine();

            Console.Write("Enter track duration (e.g., 3:45): ");
            string duration = Console.ReadLine();

            Genre genre = ChooseGenre();

            if (genre != null)
            {
                var track = new Track(trackTitle, duration, genre);
                album.AlbumTracks.Add(track);
                Console.WriteLine($"Track '{trackTitle}' added to album '{albumTitle}'.");
            }
        }
        public void AddNewGenre()
        {
            Console.Write("Enter genre name: ");
            string genreName = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(genreName))
            {
                if (genres.Exists(g => g.genreName == genreName))
                {
                    Console.WriteLine($"Genre '{genreName}' already exists.");
                }
                else
                {
                    genres.Add(new Genre(genreName));
                    Console.WriteLine($"Genre '{genreName}' added successfully.");
                }
            }
            else
            {
                Console.WriteLine("Genre name cannot be empty.");
            }
        }

        // Helper method 
        private Genre ChooseGenre()
        {
            Console.WriteLine("Choose genre:");
            for (int i = 0; i < genres.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {genres[i].genreName}");
            }
            Console.Write("Choose a number: ");
            if (int.TryParse(Console.ReadLine(), out int genreChoice) && genreChoice > 0 && genreChoice <= genres.Count)
            {
                return genres[genreChoice - 1];
            }
            else
            {
                Console.WriteLine("Invalid genre choice.");
                Console.WriteLine("Add a new genre or choose from existing list");

                return null;
            }
        }

        public void AddTrackToPlaylist()
        {
            // Ask for playlist name
            Console.Write("Enter playlist name: ");
            string playlistName = Console.ReadLine();
            var playlist = playlists.FirstOrDefault(p => p.Name.Equals(playlistName, StringComparison.OrdinalIgnoreCase));

            if (playlist == null)
            {
                Console.WriteLine($"Playlist '{playlistName}' not found.");
                return;
            }

            // Ask for artist name
            Console.Write("Enter artist name: ");
            string artistName = Console.ReadLine();
            var artist = artists.FirstOrDefault(a => a.Name.Equals(artistName, StringComparison.OrdinalIgnoreCase));

            if (artist == null)
            {
                Console.WriteLine($"Artist '{artistName}' not found.");
                return;
            }

            // Ask for album name
            Console.Write("Enter album name: ");
            string albumName = Console.ReadLine();
            var album = artist.Albums.FirstOrDefault(a => a.Title.Equals(albumName, StringComparison.OrdinalIgnoreCase));

            if (album == null)
            {
                Console.WriteLine($"Album '{albumName}' not found for artist '{artistName}'.");
                return;
            }

            // Ask for the track name
            Console.Write("Enter track title: ");
            string trackTitle = Console.ReadLine();
            var track = album.AlbumTracks.FirstOrDefault(t => t.Title.Equals(trackTitle, StringComparison.OrdinalIgnoreCase));

            if (track == null)
            {
                Console.WriteLine($"Track '{trackTitle}' not found in album '{albumName}'.");
                return;
            }

            // Add track to playlist
            playlist.AddTrack(track);
            Console.WriteLine($"Track '{trackTitle}' by {artistName} added to playlist '{playlistName}'.");
        }


    }



}
