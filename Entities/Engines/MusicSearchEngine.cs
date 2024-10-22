using MusicCatalog.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Engines
{
    class MusicSearchEngine
    {
        private List<Artist> artists;
        private List<Genre> genres;
        private List<Playlist> playlists;

        public MusicSearchEngine(List<Artist> artists, List<Genre> genres, List <Playlist> playlists)
        {
            this.artists = artists;
            this.genres = genres;
            this.playlists = playlists;
        }

        // Поиск артистов по имени
        public List<Artist> SearchArtistsByName(string name)
        {
            return artists
                .Where(artist => artist.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Поиск альбомов по жанру
        public List<Album> SearchAlbumsByGenre(Genre genre)
        {
            return artists
                .SelectMany(artist => artist.Albums)
                .Where(album => album.Genre == genre)
                .ToList();
        }

        // Поиск альбомов по году выпуска
        public List<Album> SearchAlbumsByReleaseYear(string releaseYear)
        {
            return artists
                .SelectMany(artist => artist.Albums)
                .Where(album => album.ReleaseYear == releaseYear)
                .ToList();
        }

        public List<Track> SearchTracksByTitle(string trackTitle)
        {
            return artists.SelectMany(a => a.Albums)
                          .SelectMany(album => album.AlbumTracks)
                          .Where(track => track.Title.Contains(trackTitle, StringComparison.OrdinalIgnoreCase))
                          .ToList();
        }

        // Поиск треков по жанру
        public List<Track> SearchTracksByGenre(string genreName)
        {
            var genre = genres.FirstOrDefault(g => g.genreName.Equals(genreName, StringComparison.OrdinalIgnoreCase));
            if (genre != null)
            {
                return artists.SelectMany(a => a.Albums)
                              .SelectMany(album => album.AlbumTracks)
                              .Where(track => track.Genre == genre)
                              .ToList();
            }
            return [];
        }

        // Поиск альбомов по названию альбома
        public List<Album> SearchAlbumsByTitle(string title)
        {
            return artists
                .SelectMany(artist => artist.Albums)
                .Where(album => album.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public void DisplayArtists(List<Artist> foundArtists)
        {
            if (foundArtists.Count > 0)
            {
                Console.WriteLine("Found Artists:");
                foreach (var artist in foundArtists)
                {
                    Console.WriteLine($"- {artist.Name}");
                }
            }
            else
            {
                Console.WriteLine("No artists found.");
            }
        }

        public void DisplayAllGenres()
        {
            if (genres.Count > 0)
            {
                Console.WriteLine("List of all genres: ");
                foreach (var genre in genres)
                {
                    Console.WriteLine($"- {genre.genreName}");
                }
            }
            else
            {
                Console.WriteLine("No genres found.");
            }
        }

        public void DisplayAlbums(List<Album> foundAlbums)
        {
            if (foundAlbums.Count > 0)
            {
                Console.WriteLine("Found Albums:");
                foreach (var album in foundAlbums)
                {
                    Console.WriteLine($"- {album.Title} (Released: {album.ReleaseYear})");
                }
            }
            else
            {
                Console.WriteLine("No albums found.");
            }
        }

        public void DisplayTracks(List<Track> foundTracks)
        {
            if (foundTracks.Count > 0)
            {
                Console.WriteLine("Found Tracks:");
                foreach (var track in foundTracks)
                {
                    Console.WriteLine($"- {track.Title} ({track.Time}) [Genre: {track.Genre.genreName}]");
                }
            }
            else
            {
                Console.WriteLine("No tracks found.");
            }
        }
public void DisplayTracksInPlaylist(string playlistTitle)
{
    var playlist = playlists.FirstOrDefault(p => p.Name.Equals(playlistTitle, StringComparison.OrdinalIgnoreCase));

    if (playlist == null)
    {
        Console.WriteLine($"Playlist '{playlistTitle}' not found.");
        return;
    }

    if (playlist.Tracks.Count == 0)
    {
        Console.WriteLine($"No tracks found in playlist '{playlistTitle}'.");
    }
    else
    {
        Console.WriteLine($"Tracks in playlist '{playlistTitle}':");
        foreach (var track in playlist.Tracks)
        {
            Console.WriteLine($"- {track.Title}");
        }
    }
}
        public void DisplayAllTracks()
        {
            if (artists.Count == 0)
            {
                Console.WriteLine("No artists available.");
                return;
            }

            foreach (var artist1 in artists)
            {
                Console.WriteLine($"Artist: {artist1.Name}");
                if (artist1.Albums.Count == 0)
                {
                    Console.WriteLine($"    No albums available for Artist - {artist1.Name}.");
                }
                else
                {
                    foreach (var album in artist1.Albums)
                    {
                        Console.WriteLine($"  Album: {album.Title} ({album.ReleaseYear})");
                        if (album.AlbumTracks.Count == 0)
                        {
                            Console.WriteLine($"    No tracks available. in {album.Title}");
                        }
                        else
                        {
                            foreach (var track in album.AlbumTracks)
                            {
                                Console.WriteLine($"    Track: {track.Title} | Genre: {track.Genre.genreName}");
                            }
                        }
                    }
                }
            }
        }

    }
}



