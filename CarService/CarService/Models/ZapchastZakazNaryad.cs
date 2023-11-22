using System;
using System.Collections.Generic;

namespace CarService.Models;

public partial class ZapchastZakazNaryad
{
    public int ZapchastZakazNaryadId { get; set; }

    public int ZakazNaryadId { get; set; }

    public int ZapchastId { get; set; }

    public virtual ZakazNaryad ZakazNaryad { get; set; } = null!;

    public virtual Zapchast Zapchast { get; set; } = null!;
}
