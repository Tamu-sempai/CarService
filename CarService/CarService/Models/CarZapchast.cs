using System;
using System.Collections.Generic;

namespace CarService.Models;

public partial class CarZapchast
{
    public int CarZapchastId { get; set; }

    public int CarId { get; set; }

    public int ZapchatId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Zapchast Zapchat { get; set; } = null!;
}
