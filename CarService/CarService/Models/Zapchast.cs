using System;
using System.Collections.Generic;

namespace CarService.Models;

public partial class Zapchast
{
    public int ZapchastId { get; set; }

    public string Name { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public int Count { get; set; }

    public double Price { get; set; }

    public virtual ICollection<CarZapchast> CarZapchasts { get; } = new List<CarZapchast>();

    public virtual ICollection<ZapchastZakazNaryad> ZapchastZakazNaryads { get; } = new List<ZapchastZakazNaryad>();
}
