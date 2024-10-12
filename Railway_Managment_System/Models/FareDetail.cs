using System;
using System.Collections.Generic;

namespace Railway_Managment_System.Models;

public partial class FareDetail
{
    public int FId { get; set; }

    public int? TrainId { get; set; }

    public string? Class { get; set; }

    public int? Rate { get; set; }
}
