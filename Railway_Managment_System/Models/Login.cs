﻿using System;
using System.Collections.Generic;

namespace Railway_Managment_System.Models;

public partial class Login
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? Roletype { get; set; }
}
