using System;
using System.Collections.Generic;

namespace MusikApp.Models;

public class Playlist
{
    public int PlaylistId { get; set; }
    public string? Name { get; set; }
    public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new List<PlaylistTrack>();

}

