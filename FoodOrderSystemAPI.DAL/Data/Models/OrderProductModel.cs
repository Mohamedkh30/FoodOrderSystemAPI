using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public class OrderProductModel
{
    [Range(0, int.MaxValue, ErrorMessage = "Quantity Should Be Positive")]
    public int? Quantity { get; set; }


    [ForeignKey(nameof(Order))]
    [Key]
    [Column(Order = 1)]
    public int? OrderId { get; set; }

    [Key]
    [Column(Order = 2)]
    [ForeignKey(nameof(Product))]
    public int? ProductId { get; set; }


    public  OrderModel Order { get; set; }
    public  ProductModel Product { get; set; }
}
