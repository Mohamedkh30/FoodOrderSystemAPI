using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public class OrderModel
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    
    public int TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public string? OrderStatus { get; set; }

    public CustomerModel Customer { get; set; }

}
