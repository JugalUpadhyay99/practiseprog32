﻿using System;
using System.Collections.Generic;

namespace practiseprog32;

public partial class UserMaster
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public bool? IsDeleted { get; set; }
}
