using System;
using System.Collections.Generic;

namespace MusikApp.Models;

public partial class Type
{
    public int? Integer { get; set; }

    public double? Float { get; set; }

    public string? String { get; set; }

    public DateTime? DateTime { get; set; }

    public int? Bool { get; set; }
}
