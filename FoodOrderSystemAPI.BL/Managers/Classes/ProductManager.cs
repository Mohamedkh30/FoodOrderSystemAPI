using FoodOrderSystemAPI.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
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
            var product = new ProductModel()
            {
                describtion = productDto.describtion,
                img = productDto.img,
                offer = productDto.offer,
                price = productDto.price,
                Productname = productDto.Productname,
                rate = productDto.rate,
                type = productDto.type,

                //ID=productDto.ID,
                restaurant = productDto.restaurant,
            };

            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
            return productDto.ID;
        }

        public void delete(int id)
        {
            ProductModel? productToDelete = _unitOfWork.Products.GetById(id);
            if (productToDelete is null)
                return;
            _unitOfWork.Products.Delete(productToDelete);
            _unitOfWork.Save();
        }

        public List<FullProductDto> GetAll()
        {
            return _unitOfWork.Products.GetAll().Select(p => new FullProductDto() 
            {
                ID= p.ProductId,
                describtion= p.describtion,
                img= p.img,
                offer = p.offer,
                price = p.price,
                Productname = p.Productname,
                rate = p.rate,
                type = p.type,

                restaurant= p.restaurant,
            }).ToList();
        }

        public FullProductDto? GetById(int id)
        {
            ProductModel? ProductToRead = _unitOfWork.Products.GetById(id);
            if (ProductToRead is null)
                return null;
            return new FullProductDto()
            {
                ID = ProductToRead.ProductId,
                describtion = ProductToRead.describtion,
                img = ProductToRead.img,
                offer = ProductToRead.offer,
                price = ProductToRead.price,
                Productname = ProductToRead.Productname,
                rate = ProductToRead.rate,
                type = ProductToRead.type,

                restaurant = ProductToRead.restaurant,
            };
        }

        public void update(FullProductDto productDto)
        {
            ProductModel? ProductfromDb = _unitOfWork.Products.GetById(productDto.ID);
            if (ProductfromDb is null)
                return;

            ProductfromDb.describtion = productDto.describtion;
            ProductfromDb.img = productDto.img;
            ProductfromDb.offer = productDto.offer;
            ProductfromDb.price = productDto.price;
            ProductfromDb.Productname = productDto.Productname;
            ProductfromDb.rate = productDto.rate;
            ProductfromDb.type = productDto.type;

            ProductfromDb.restaurant = productDto.restaurant;

            _unitOfWork.Products.Update(ProductfromDb);
            _unitOfWork.Save();
        }
    }
}
