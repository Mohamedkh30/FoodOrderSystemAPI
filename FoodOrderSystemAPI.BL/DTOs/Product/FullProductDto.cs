using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{
    public class FullProductDto
    {
        public int ProductID { get; set; }

        public String Productname { get; set; } = "";

        public float price { get; set; }

        public String describtion { get; set; } = "";

        public String img { get; set; } = "";

        public float offer { get; set; }

        public float rate { get; set; }

        public String type { get; set; } = "";

        public RestaurantModel restaurant { get; set; }
    }
}
