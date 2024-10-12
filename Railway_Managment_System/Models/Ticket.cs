using System;
using System.Collections.Generic;

namespace Railway_Managment_System.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public int? Passengers { get; set; }

    public DateOnly? DateOfTarvel { get; set; }

    public string? Class { get; set; }

    public int? TrainId { get; set; }

    public int? TotalFair { get; set; }

    public virtual Train? Train { get; set; }
}
