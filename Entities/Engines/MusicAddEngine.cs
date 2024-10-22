﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Entities.Engines
{
    using MusicCatalog.Entities.Common;
    using System;
    using System.Collections.Generic;

    class MusicAddEngine
    {
        private List<Artist> artists;
        private List<Genre> genres;
        private List<Playlist> playlist;

        public MusicAddEngine(List<Artist> artists, List<Genre> genres, List<Playlist> playlist)
        {
            this.artists = artists;
            this.genres = genres;
            this.playlist = playlist;
        }

        // Method to add a new artist
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

        // Method to add a new album
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

        // Method to add a new track
        public void AddNewTrack()
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
            var album = artist.Albums.Find(a => a.Title == albumTitle);
            if (album == null)
            {
                Console.WriteLine($"Album '{albumTitle}' not found for artist '{artistName}'.");
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

        // Method to add a new genre
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

        // Helper method to choose genre from the existing list
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
                return null;
            }
        }


    }



}