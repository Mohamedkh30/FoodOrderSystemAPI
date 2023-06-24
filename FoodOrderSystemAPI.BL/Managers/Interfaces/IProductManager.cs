using FoodOrderSystemAPI.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{
    public interface IProductManager
    {
        List<string> GetProductTags();
        List<float> GetProductPricesBounds();
        List<ProductCardDto> GetAll();
        List<ProductCardDto> GetAllFilterTag(List<string> FilterTags);
        List<ProductCardDto> GetAllFilterRestaurant(List<string> FilterRestaurants);
        List<ProductCardDto> GetAllFilterPrice(List<float> FilterPrices);
        List<ProductCardDto> searchProductByName(string word);
        ProductCardDto? GetById(int id);
        int Add(ProductCardDto productDto);
        void update(ProductCardDto productDto);
        void delete(int id);
    }
}
