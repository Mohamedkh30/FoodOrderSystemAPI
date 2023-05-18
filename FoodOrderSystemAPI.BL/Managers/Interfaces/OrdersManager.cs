using FoodOrderSystemAPI.BL.DTOs;
using FoodOrderSystemAPI.BL.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL
{
    public class OrdersManager : IOrdersManager
    {
        private readonly IOrderRepo _ordersRepo;

        public OrdersManager(IOrderRepo ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }
        public int Add(OrderAddDto orderDto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderReadDto> GetAll()
        {
            IEnumerable<OrderModel> ordersFromDb = (IEnumerable<OrderModel>)_ordersRepo.GetAll();
            return ordersFromDb.Select(d => new OrderReadDto
            {
                OrderId = d.OrderId,
                CustomerId = d.CustomerId,
                OrderDate = d.OrderDate,
                TotalPrice = d.TotalPrice,           


            }).ToList();


        }

        public OrderReadDetailDto? GetById(int id)
        {
            var order = _ordersRepo.GetById(id);
        }

        public void update(OrderUpdateDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
