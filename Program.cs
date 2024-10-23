using MusicCatalog.Entities.Common;
using MusicCatalog.Entities.Engines;
using MusicCatalog.Entities.Patterns;
using System;
using System.Collections.Generic;

class Program
{
    static List<Artist> artists = new List<Artist>();
    static List<Genre> genres = new List<Genre>();
    static List<Playlist> playlists = new List<Playlist>();

    static void Main(string[] args)
    {
        Cataloge();  // Fill the catalog with some data for testing

        MusicAddEngine addEngine = new MusicAddEngine(artists, genres, playlists);
        MusicSearchEngine searchEngine = new MusicSearchEngine(artists, genres, playlists);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Music Catalog!");
            Console.WriteLine("1.    Add Artist");
            Console.WriteLine("2.    Add Album");
            Console.WriteLine("3.    Add Track");
            Console.WriteLine("4.    Add Genre");
            Console.WriteLine("5.    Search Artists by Name");
            Console.WriteLine("6.    Search Albums by Title");
            Console.WriteLine("7.    Search Tracks by Title");
            Console.WriteLine("8.    Search Tracks by Genre");
            Console.WriteLine("9.    Search Albums by Release Year");
            Console.WriteLine("10.   Display all Artists");
            Console.WriteLine("11.   Display all Tracks");
            Console.WriteLine("12.   Display all Genres");
            Console.WriteLine("13.   Add Playlist");
            Console.WriteLine("14.   Display Playlist Tracks");
            Console.WriteLine("15.   Add Track in Playlist");
            Console.WriteLine("16.   Display all Playlists");

            Console.WriteLine("0.    Exit");
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
                case "13":
                    addEngine.AddNewPlaylist();
                    break;
                case "14":
                    Console.Write("Enter playlist name:");
                    string playlistTitle = Console.ReadLine();
                    searchEngine.DisplayTracksInPlaylist(playlistTitle);
                    break;
                case "15":
                    addEngine.AddTrackToPlaylist();
                    break;
                case "16":
                    searchEngine.DisplayAllPlaylists();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void Cataloge()
    {
        MusicFactory factory = new MusicFactory();

        Genre pop = factory.CreateGenre("Pop");
        Genre rock = factory.CreateGenre("Rock");
        Genre jazz = factory.CreateGenre("Jazz");

        genres.Add(pop);
        genres.Add(rock);
        genres.Add(jazz);

        Artist artist1 = factory.CreateArtist("Artist 1");
        Artist artist2 = factory.CreateArtist("Artist 2");

        // Build album for artist1

        AlbumBuilder builder1 = new AlbumBuilder();
        Album album1 = builder1
                .SetTitle("My POP Album Title")
                .SetReleaseYear("2024")
                .SetGenre(pop)
                .AddTrack(new Track("Track 5", "3:45", pop))
                .AddTrack(new Track("Track 6", "4:15", pop))
                .Build();

        artist1.Albums.Add(album1);

        // Build album for artist2
        AlbumBuilder builder2 = new AlbumBuilder();
        Album album2 = builder2
        .SetTitle("My ROCK Album Title")
        .SetReleaseYear("2024")
        .SetGenre(rock)
        .AddTrack(new Track("Track 7", "3:45", rock))
        .AddTrack(new Track("Track 8", "4:15", rock))
        .Build();

        artist2.Albums.Add(album2);

        // Add artists to the list
        artists.Add(artist1);
        artists.Add(artist2);

        // Create a playlist and add albums
        Playlist playlist1 = factory.CreatePlaylist("My Playlist");
        playlist1.AddAlbum(album1);
        playlist1.AddAlbum(album2);

        playlists.Add(playlist1);
    }

} 


