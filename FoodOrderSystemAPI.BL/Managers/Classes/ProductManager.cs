using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{
    public class ProductManager : IProductManager
    {
        private IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork) {
            _unitOfWork=unitOfWork;
        }

        public int Add(FullProductDto productDto)
        {
            //return _unitOfWork.Products.Add();
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<FullProductDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public FullProductDto? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(FullProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
