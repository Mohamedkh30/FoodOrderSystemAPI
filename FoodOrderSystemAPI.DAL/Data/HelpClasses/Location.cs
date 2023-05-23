using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;
[NotMapped]

public class Location
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    [ForeignKey(nameof(Customer))]
    public string CustomerId { get; set; }
    public virtual CustomerModel? Customer { get; set; }
    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
