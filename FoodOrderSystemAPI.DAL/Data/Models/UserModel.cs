using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FoodOrderSystemAPI;

public class UserModel:IdentityUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override string Id { get; set; }

    [Required]
    public override  string NormalizedUserName { get; set; } = string.Empty;

    [EmailAddress]
    [Required]
    public override string NormalizedEmail { get; set; }

    public string Role { get; set; }

}

