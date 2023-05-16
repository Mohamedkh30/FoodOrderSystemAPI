using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI
{
    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [NotMapped]
        public Location? Location { get; set; }


        public string CreditCard { get; set; }

        public string Email { get; set; }

        public ICollection<OrderModel> Orders { get; set; } = new HashSet<OrderModel>();
        public ICollection<ReviewModel> Reviews { get; set; } = new HashSet<ReviewModel>();






    }
}
