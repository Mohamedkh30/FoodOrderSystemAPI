using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;
    public enum status
{
    preparing,
    enRoute,
    recived

}

public class OrderModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int ID { get; set; }
    public float Total_Price { get; set; }
    public DateTime date { get; set; }

    public status Order_Status { get; set; }
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    public  CustomerModel? Customer { get; set; }
    public  ICollection <OrderProductModel> Order_Product { get; set; }


}
