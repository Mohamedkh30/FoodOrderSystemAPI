using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{
    public interface IProductManager
    {
        List<ProductCardDto> GetAll();
        ProductCardDto? GetById(int id);
        int Add(ProductAddDto productDto);
        void update(ProductCardDto productDto);
        void delete(int id);
    }
}
