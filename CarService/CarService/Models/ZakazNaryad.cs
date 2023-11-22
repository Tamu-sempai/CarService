using System;
using System.Collections.Generic;

namespace CarService.Models;

public partial class ZakazNaryad
{
    public int ZakazNaryadId { get; set; }

    public int ClientId { get; set; }

    public int WorkZakazNaryadId { get; set; }

    public int CarClientId { get; set; }

    public int ZapchastZakazNaryadId { get; set; }

    public DateTime EndDate { get; set; }

    public double TotalCoast { get; set; }

    public DateTime? StartDate { get; set; }

    public virtual CarClient CarClient { get; set; } = null!;

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<WorkZakazNaryad> WorkZakazNaryads { get; } = new List<WorkZakazNaryad>();

    public virtual ICollection<ZapchastZakazNaryad> ZapchastZakazNaryads { get; } = new List<ZapchastZakazNaryad>();
}
