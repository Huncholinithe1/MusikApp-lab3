using System;
using System.Collections.Generic;

namespace MusikApp.Models;

public partial class Color
{
    public string? HexCode { get; set; }
    public int Id { get; set; }  
    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public int? Red { get; set; }

    public int? Green { get; set; }

    public int? Blue { get; set; }
}
