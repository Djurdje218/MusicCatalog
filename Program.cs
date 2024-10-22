using MusicCatalog.Entities.Common;
using MusicCatalog.Entities.Engines;
using System;
using System.Collections.Generic;

class Program
{
    static List<Artist> artists = new List<Artist>();
    static List<Genre> genres = new List<Genre>();
    static List<Playlist> playlists = new List<Playlist>();

    static void Main(string[] args)
    {
        SeedData();  // Pre-populate the catalog with some data for testing

        MusicAddEngine addEngine = new MusicAddEngine(artists, genres,playlists);
        MusicSearchEngine searchEngine = new MusicSearchEngine(artists, genres,playlists);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Music Catalog!");
            Console.WriteLine("1. Add Artist");
            Console.WriteLine("2. Add Album");
            Console.WriteLine("3. Add Track");
            Console.WriteLine("4. Add Genre");
            Console.WriteLine("5. Search Artists by Name");
            Console.WriteLine("6. Search Albums by Title");
            Console.WriteLine("7. Search Tracks by Title");
            Console.WriteLine("8. Search Tracks by Genre");
            Console.WriteLine("9. Search Albums by Release Year");
            Console.WriteLine("10. Display all Artists");
            Console.WriteLine("11. Display all Tracks");
            Console.WriteLine("12. Display all Genres");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();
            Console.WriteLine("\n");

            switch (option)
            {
                case "1":
                    addEngine.AddNewArtist();
                    break;
                case "2":
                    addEngine.AddNewAlbum();
                    break;
                case "3":
                    addEngine.AddNewTrack();
                    break;
                case "4":
                    addEngine.AddNewGenre();
                    break;
                case "5":
                    Console.Write("Enter artist name: ");
                    string artistName = Console.ReadLine();
                    var foundArtists = searchEngine.SearchArtistsByName(artistName);
                    searchEngine.DisplayArtists(foundArtists);
                    break;
                case "6":
                    Console.Write("Enter album title: ");
                    string albumTitle = Console.ReadLine();
                    var foundAlbums = searchEngine.SearchAlbumsByTitle(albumTitle);
                    searchEngine.DisplayAlbums(foundAlbums);
                    break;
                case "7":
                    Console.Write("Enter track title: ");
                    string trackTitle = Console.ReadLine();
                    var foundTracks = searchEngine.SearchTracksByTitle(trackTitle);
                    searchEngine.DisplayTracks(foundTracks);
                    break;
                case "8":
                    Console.Write("Enter genre name: ");
                    string genreName = Console.ReadLine();
                    var foundGenreTracks = searchEngine.SearchTracksByGenre(genreName);
                    searchEngine.DisplayTracks(foundGenreTracks);
                    break;
                case "9":
                    Console.Write("Enter release year: ");
                    string releaseYear = Console.ReadLine();
                    var foundYearAlbums = searchEngine.SearchAlbumsByReleaseYear(releaseYear);
                    searchEngine.DisplayAlbums(foundYearAlbums);
                    break;
                case "0":
                    return;
                case "10":
                    searchEngine.DisplayArtists(artists);
                    break;
                case "11":
                    searchEngine.DisplayAllTracks();
                    break;
                case "12":
                    searchEngine.DisplayAllGenres();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    // Pre-populate the catalog with some data
    static void SeedData()
    {
        Genre pop = new Genre("Pop");
        Genre rock = new Genre("Rock");
        genres.Add(pop);
        genres.Add(rock);

        Artist artist1 = new Artist("Artist 1");
        Album album1 = new Album("Album 1", "2020", pop);
        album1.AlbumTracks.Add(new Track("Track 1", "3:45", pop));
        artist1.Albums.Add(album1);

        Artist artist2 = new Artist("Artist 2");
        Album album2 = new Album("Album 2", "2021", rock);
        album2.AlbumTracks.Add(new Track("Track 2", "4:15", rock));
        artist2.Albums.Add(album2);

        artists.Add(artist1);
        artists.Add(artist2);
    }
}


