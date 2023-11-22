using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CarService.Models;

public partial class CarClient : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void notifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public int CarClientId { get; set; }

    public string Vin { get; set; } = null!;

    public int ClientId { get; set; }

    public string Marka { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string TypeEngine { get; set; } = null!;

    public int YearRelese { get; set; }

    public int Run { get; set; }

    public string StateNumber { get; set; } = null!;

    public string Color { get; set; } = null!;

    public DateTime DateRegistration { get; set; }

    private string? ImageCar { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<ZakazNaryad> ZakazNaryads { get; } = new List<ZakazNaryad>();
    public string? imageCar
    {
        get => ImageCar;
        set
        {
            ImageCar = value;
            notifyPropertyChanged(nameof(imageCar));
        }
    }
}
