using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;
[Table("RestaurantModel")]

public class RestaurantModel:UserModel
{ 
    public string Name { get; set; }
    public byte[] Logo { get; set; }
    [NotMapped]
    public Location ResturantLocation { get; set; }
    public string Phone { get; set; }
 


    public virtual ICollection<ProductModel> Products { set; get; } = new HashSet<ProductModel>();


}
