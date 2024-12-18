using System;
using System.Collections.Generic;

namespace MusikApp.Models;

public partial class Airport
{
    public string Iata { get; set; } = null!;

    public string? Icao { get; set; }

    public string? AirportName { get; set; }

    public string? LocationServed { get; set; }

    public string? Time { get; set; }

    public string? Dst { get; set; }
}
