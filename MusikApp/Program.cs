using Microsoft.EntityFrameworkCore;
using MusikApp.Models;
using System.Threading;

namespace MusikApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<EveryloopContext>()
                .UseSqlServer("Server=DILAN;Database=everyloop;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            using var context = new EveryloopContext(options);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- Playlist Menu ---");
                Console.WriteLine("1. Classical");
                Console.WriteLine("2. Classical 101 - Deep cuts");
                Console.WriteLine("3. Grunge");
                Console.WriteLine("4. Heavy Metal");
                Console.WriteLine("5. Brazilian");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var option = Console.ReadLine();
                string playlistName = option switch
                {
                    "1" => "Classical",
                    "2" => "Classical 101 - Deep cuts",
                    "3" => "Grunge",
                    "4" => "Heavy Metal Classic",
                    "5" => "Brazilian Music",
                    "6" => null,
                    _ => null,

                };

                if (playlistName == null)
                {
                    if (option == "6")
                    {
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Invalid option. Please choose again.");
                    continue;
                }

                var playlist = context.Playlists
                    .Include(p => p.PlaylistTracks)
                    .ThenInclude(pt => pt.Track)
                    .FirstOrDefault(p => p.Name == playlistName);



                if (playlist == null)
                {
                    Console.WriteLine($"Playlist '{playlistName}' not found.");
                    continue;
                }

                DisplayCRUDMenu(context, playlist);

                Console.WriteLine($"\n--- Tracks in Playlist: {playlistName} ---");
                foreach (var playlistTrack in playlist.PlaylistTracks)
                {
                    var track = playlistTrack.Track;
                    Console.WriteLine($"Track ID: {track.TrackId}, Name: {track.Name}, Composer: {track.Composer}");
                }

                
            }
        }

        static void DisplayCRUDMenu(EveryloopContext context, Playlist playlist)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n--- Manage Playlist: {playlist.Name} ---");
                Console.WriteLine("1. List All Tracks");
                Console.WriteLine("2. Add a New Track");
                Console.WriteLine("3. Update a Track");
                Console.WriteLine("4. Delete a Track");
                Console.WriteLine("5. Back to Playlist Menu");
                Console.Write("Choose an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        DisplayTracksByPlaylist(context, playlist);
                        break;
                    case "2":
                        AddTrack(context, playlist);
                        
                        break;
                    case "3":
                        UpdateTrack(context, playlist);                      
                        break;
                    case "4":
                        DeleteTrack(context, playlist);
                        break;                       
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        static void DisplayTracksByPlaylist(EveryloopContext context, Playlist playlist)
        {
            Console.Clear();
            Console.WriteLine($"\n--- Tracks in Playlist: {playlist.Name} ---");
            foreach (var playlistTrack in playlist.PlaylistTracks)
            {
                var track = playlistTrack.Track;
                Console.WriteLine($"Track ID: {track.TrackId}, Name: {track.Name}, Composer: {track.Composer}");
            }
        }

        static void AddTrack(EveryloopContext context, Playlist playlist)
        {
            Console.Clear();
            Console.Write("Enter track name: ");
            string name = Console.ReadLine();

            var newTrack = new Track
            {
                Name = name,
                AlbumId = 1,
                MediaTypeId = 1,
                GenreId = 1,
                Composer = "Unknown",
                Milliseconds = 200000,
                UnitPrice = 1.29
            };

            context.Tracks.Add(newTrack);
            context.SaveChanges();

            var playlistTrack = new PlaylistTrack
            {
                PlaylistId = playlist.PlaylistId,
                TrackId = newTrack.TrackId
            };

            context.PlaylistTracks.Add(playlistTrack);
            context.SaveChanges();

            Console.WriteLine("New track added to playlist!");
        }

        static void UpdateTrack(EveryloopContext context, Playlist playlist)
        {
            Console.Write("Enter the Track ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int trackId))
            {
                var track = context.Tracks.FirstOrDefault(t => t.TrackId == trackId);
                if (track == null)
                {
                    Console.WriteLine("Track not found.");
                    return;
                }

                Console.Write("Enter new name for the track: ");
                track.Name = Console.ReadLine();
                context.SaveChanges();

                Console.WriteLine("Track updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Track ID.");
            }
        }

        static void DeleteTrack(EveryloopContext context, Playlist playlist)
        {
            Console.Write("Enter the Track ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int trackId))
            {
                var track = context.Tracks.FirstOrDefault(t => t.TrackId == trackId);
                if (track == null)
                {
                    Console.WriteLine("Track not found.");
                    return;
                }

                var playlistTrack = context.PlaylistTracks
                    .FirstOrDefault(pt => pt.PlaylistId == playlist.PlaylistId && pt.TrackId == trackId);

                if (playlistTrack != null)
                {
                    context.PlaylistTracks.Remove(playlistTrack);
                }

                context.Tracks.Remove(track);
                context.SaveChanges();

                Console.WriteLine("Track deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Track ID.");
            }
        }
    }
}
