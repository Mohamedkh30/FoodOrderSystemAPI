using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI;

[NotMapped]
public class CreditCard
{
    [ForeignKey(nameof(Customer))]
    public string CustomerId { get; set; }
    public virtual CustomerModel? Customer { get; set; }
    public int Card_Number { get; set; }
    public DateTime Card_Expiration_Date { get; set; }
    public short CVV  { get; set; }
}
