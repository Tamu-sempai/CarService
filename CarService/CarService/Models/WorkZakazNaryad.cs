using System;
using System.Collections.Generic;

namespace CarService.Models;

public partial class WorkZakazNaryad
{
    public int WorkZakazNaryadId { get; set; }

    public int ZakazNaryadId { get; set; }

    public int WorkId { get; set; }

    public virtual Work Work { get; set; } = null!;

    public virtual ZakazNaryad ZakazNaryad { get; set; } = null!;
}
