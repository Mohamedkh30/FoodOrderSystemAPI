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

        public int Add(ProductCardDto productDto)           //not working (move to DAL? | )
        {
            var product = new ProductModel()
            {
                ProductId= productDto.ProductID,
                describtion = productDto.describtion,
                img = productDto.img,
                offer = productDto.offer,
                price = productDto.price,
                Productname = productDto.Productname,
                rate = productDto.rate,
            };
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
            foreach (var tag in productDto.tags)
            {
                _unitOfWork.ProductTags.Add(new ProductTag { ProductId= productDto.ProductID,tag= tag});
            }

            
            _unitOfWork.Save();
            return productDto.ProductID;
        }

        public void delete(int id)
        {
            ProductModel? productToDelete = _unitOfWork.Products.GetById(id);
            if (productToDelete is null)
                return;

            IEnumerable<ProductTag>? tagsToDelete = _unitOfWork.ProductTags.GetAll().Where(t=>t.ProductId==id);
            _unitOfWork.Products.Delete(productToDelete);
            foreach(var tag in tagsToDelete)
            {
                _unitOfWork.ProductTags.Delete(tag);
            }
            _unitOfWork.Save();
        }

        public List<ProductCardDto> GetAll()
        {
            var products = _unitOfWork.Products.GetAll().Select(p => new ProductCardDto() 
            {
                ProductID = p.ProductId,
                describtion= p.describtion,
                img= p.img,
                offer = p.offer,
                price = p.price,
                Productname = p.Productname,
                rate = p.rate,
                restaurantID = p.RestaurantID,
                restaurantName = p.restaurant.RestaurantName,
            }).ToList();

            foreach (var product in products)
            {
                product.tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == product.ProductID).Select(t => t.tag).ToList();
            }
            return products;

        }

        public ProductCardDto? GetById(int id)
        {
            ProductModel? ProductToRead = _unitOfWork.Products.GetById(id);
            if (ProductToRead is null)
                return null;
            return new ProductCardDto()
            {
                ProductID = ProductToRead.ProductId,
                describtion = ProductToRead.describtion,
                img = ProductToRead.img,
                offer = ProductToRead.offer,
                price = ProductToRead.price,
                Productname = ProductToRead.Productname,
                rate = ProductToRead.rate,
                tags = _unitOfWork.ProductTags.GetAll().Where(t => t.ProductId == ProductToRead.ProductId).Select(t => t.tag).ToList(),
                restaurantID = ProductToRead.restaurant.Id,
                restaurantName = ProductToRead.restaurant.RestaurantName,
            };
        }

        public void update(ProductCardDto productDto)           // doesn't update tag list
        {
            ProductModel? ProductfromDb = _unitOfWork.Products.GetById(productDto.ProductID);
            if (ProductfromDb is null)
                return;

            ProductfromDb.describtion = productDto.describtion;
            ProductfromDb.img = productDto.img;
            ProductfromDb.offer = productDto.offer;
            ProductfromDb.price = productDto.price;
            ProductfromDb.Productname = productDto.Productname;
            ProductfromDb.rate = productDto.rate;

            _unitOfWork.Products.Update(ProductfromDb);
            _unitOfWork.Save();
        }
    }
}
