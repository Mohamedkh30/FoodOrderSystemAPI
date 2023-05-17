using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL.DTOs.Product
{
    internal class FullProductDto
    {
        public int ID;

        public String Productname = "";

        public float price;

        public String describtion = "";

        public String img = "";

        public float offer;

        public float rate;

        public String type = "";

        public RestaurantModel restaurant;
    }
}
