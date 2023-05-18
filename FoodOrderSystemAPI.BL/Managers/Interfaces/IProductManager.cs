using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{
    public interface IProductManager
    {
        List<FullProductDto> GetAll();
        FullProductDto? GetById(int id);
        int Add(FullProductDto productDto);
        void update(FullProductDto productDto);
        void delete(int id);
    }
}
