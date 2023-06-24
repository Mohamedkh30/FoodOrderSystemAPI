using FoodOrderSystemAPI.DAL;
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
        ProductCardDto? GetById(int id);
        int Add(ProductCardDto productDto);
        void update(ProductCardDto productDto);
        void delete(int id);
    }
}
