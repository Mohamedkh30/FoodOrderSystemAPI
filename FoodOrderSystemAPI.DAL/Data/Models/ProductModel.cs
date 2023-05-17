using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

public class ProductModel
{
    public int ID;

    public String Productname = "";

    [Range(0f, float.MaxValue)]     //only +ve values
    public float price;         

    public String describtion = "";

    public String img = "";

    [Range(0f,1f)]
    public float offer;    
    
    [Range(0f,5f)]
    public float rate;    
    
    public String type = "";

    public RestaurantModel restaurant;

    public ICollection<OrderProductModel> orderProducts = new HashSet<OrderProductModel>();

    public ICollection<ReviewModel> reviews = new HashSet<ReviewModel>();
}
