using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CarService.Models;

public partial class Car : INotifyPropertyChanged
{ 
    public event PropertyChangedEventHandler? PropertyChanged;

    private void notifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public int CarId { get; set; }

    public string Marka { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string TypeEngine { get; set; } = null!;

    private string? ImageCar { get; set; }

    public virtual ICollection<CarZapchast> CarZapchasts { get; } = new List<CarZapchast>();
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

