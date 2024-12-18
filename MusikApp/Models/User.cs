using System;
using System.Collections.Generic;

namespace MusikApp.Models;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
