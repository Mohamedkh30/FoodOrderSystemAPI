using FoodOrderSystemAPI.BL.DTOs;
using FoodOrderSystemAPI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL.Managers.Classes
{
    public class OrdersManager : IOrdersManager
    {
        private readonly IUnitOfWork _unit;

        public OrdersManager(IUnitOfWork ordersRepo)
        {
            _unit = ordersRepo;
        }
        public int Add(OrderAddDto orderDto)
        {
            var order = _unit.Orders.GetById(orderDto.OrderId);
            if (order is null)
                throw new Exception("Not Found Order Id");

            OrderModel newOrder = new OrderModel
            {
                OrderId = orderDto.OrderId,
                CustomerId = orderDto.CustomerId,
                TotalPrice = orderDto.TotalPrice,
                OrderDate = orderDto.OrderDate,
            };
            _unit.Orders.Add(newOrder);
            _unit.Save();

            return newOrder.OrderId;
        }

        public void Delete(int id)
        {
            OrderModel? targetedOrder = _unit.Orders.GetById(id);
            if (targetedOrder is null)
                throw new Exception("Order Not Found");

            _unit.Orders.Delete(targetedOrder);
            _unit.Save();
        }

        public List<OrderReadDto> GetAll()
        {
            IEnumerable<OrderModel> ordersFromDb = _unit.Orders.GetAll();
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
            OrderModel? order = _unit.Orders.GetById(id);
            if (order is null)
                return null;

            return new OrderReadDetailDto
            {
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
            };
        }

        public void update(OrderUpdateDto orderDto)
        {
            var targetOrder = _unit.Orders.GetById(orderDto.OrderId);
            if (targetOrder is null)
                throw new Exception("Order Not Found !");

            var targetCustomer = _unit.Customers.GetById(orderDto.CustomerId);
            if (targetCustomer is null)
                throw new Exception("Customer Not Found");

            targetOrder.OrderId = orderDto.OrderId;
            targetOrder.CustomerId = orderDto.CustomerId;
            targetOrder.TotalPrice = orderDto.TotalPrice;

            _unit.Orders.Update(targetOrder);
            _unit.Save();
        }
    }
}

