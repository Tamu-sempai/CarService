using System;
using System.Collections.Generic;

namespace CarService.Models;

public partial class Work
{
    public int WorkId { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<WorkZakazNaryad> WorkZakazNaryads { get; } = new List<WorkZakazNaryad>();
}
