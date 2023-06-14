using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;
[Table("RestaurantModel")]

public class RestaurantModel : UserModel
{
    //public int RestaurantId { set; get; }

    [Required(ErrorMessage = "Please, Enter Valied Restaurant name!")]
    public string RestaurantName { set; get; } = string.Empty;

    [Required(ErrorMessage = "Address is required.")]
    public string Address { set; get; } = string.Empty;

    public string Logo { set; get; } = string.Empty;

    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number should only contain numeric digits.")]
    public int Phone { set; get; }

    public string PaymentDetails { set; get; } = string.Empty;

    //public string Email { set; get; } = string.Empty;

    //[Required(ErrorMessage = "Username is required.")]
    //public string Username { set; get; } = string.Empty;

    //[Required(ErrorMessage = "Password is required.")]
    //[MinLength(8, ErrorMessage = "Password should be at least 8 characters long.")]
    //public string Password { set; get; } = string.Empty;

    // 1-M Relation with product
    ICollection<ProductModel> Products { set; get; } = new HashSet<ProductModel>();
}
