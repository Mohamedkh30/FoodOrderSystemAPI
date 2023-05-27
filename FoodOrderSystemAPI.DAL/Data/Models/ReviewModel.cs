using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public class ReviewModel
{
    [ForeignKey(nameof(Customer))]
    [Key]
    [Column(Order = 1)]
    public int CustomerID { get; set; }
    [ForeignKey(nameof(Product))]
    [Key]
    [Column(Order = 2)]
    public int ProductID { get; set; }
    public string? Comment { get; set; }
    [Range(0,5)]
    public float Rating { get; set; }
    public  ProductModel Product { get; set; }


    public  CustomerModel Customer { get; set; }

    


  
}
