using FoodOrderSystemAPI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class CustomerToRegister
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // Email Properties 

    [EmailAddress] 
    public string Email { get; set; }

    //Password Validation 

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
      ErrorMessage = "The password must contain at least 8 characters, including one lowercase letter," +
        " one uppercase letter, one digit, and one special character.")]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConnfirmedPassword  { get; set; }

    // Location Properties 
    public double Langitude { get; set; }
    public double Landitude { get; set; }

    // Card Properties 

    [RegularExpression(@"^[0-9]{16}$", ErrorMessage = "Invalid card number.")]
    public string? CardNumber { get; set; }

    [Display(Name = "Customer Birth")]
    [DataType(DataType.Date)]
    [DateInFuture(ErrorMessage = "Your Credit Is Expired.")]
    public DateTime ExpirationDate  { get; set; }

    [RegularExpression(@"^[0-9]{3}$", ErrorMessage = "Invalid CVV number.")]
    public string CvvNumber { get; set; }

    // Phone Number 

    [Phone]
    public string Phone { get; set; }

    // Date Of Birth Validation 
    [Display(Name = "Customer Birth")]
    [DataType(DataType.Date)]
    [DateInPast(ErrorMessage = "The {0} must be a date in the past.")]
    public DateTime CustomerBirth { get; set; }






}
