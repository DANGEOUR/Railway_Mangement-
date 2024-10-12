using System;
using System.Collections.Generic;

namespace Railway_Managment_System.Models;

public partial class Train
{
    public int Id { get; set; }

    public string? TrainName { get; set; }

    public string? Departure { get; set; }

    public TimeOnly? DepartureTime { get; set; }

    public string? Arrival { get; set; }

    public int? Capacity { get; set; }

    public int? OneAc { get; set; }

    public int? TwoAc { get; set; }

    public int? ThreeAc { get; set; }

    public int? Sleeper { get; set; }

    public int? General { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
