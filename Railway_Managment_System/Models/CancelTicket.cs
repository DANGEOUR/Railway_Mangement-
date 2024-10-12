using System;
using System.Collections.Generic;

namespace Railway_Managment_System.Models;

public partial class CancelTicket
{
    public int CId { get; set; }

    public string? PassengerName { get; set; }

    public string? PassengerEmail { get; set; }
}
