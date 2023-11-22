using System;
using System.Collections.Generic;

namespace CarService.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Fio { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string NumberPhone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? ImageClient { get; set; }

    public virtual ICollection<CarClient> CarClients { get; } = new List<CarClient>();

    public virtual ICollection<ZakazNaryad> ZakazNaryads { get; } = new List<ZakazNaryad>();
}
