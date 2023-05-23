using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public class ProductModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }


    public string Name { get; set; }
    public float Price { get; set; }
    public string discription  { get; set; }
    public byte[] Img  { get; set; }
    public float Offer  { get; set; }
    public float Rate { get; set; }
    public string Type { get; set; }
    [ForeignKey(nameof(Resturant))]
    public string ResturantId { get; set; }
    public virtual RestaurantModel Resturant { get; set; }
    public virtual ICollection<OrderProductModel> Order_Product { get; set; } =  new HashSet<OrderProductModel>();

    public virtual ICollection<ReviewModel> Reviews { get; set; } = new HashSet<ReviewModel>();


}
