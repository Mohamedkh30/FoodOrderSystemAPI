namespace FoodOrderSystemAPI;

public interface IOrderRepo 
{
    //void CreateOrder(OrderRepo order);
    //OrderRepo GetOrderById(int orderId);
    List<OrderModel> GetOrdersByCustomerId(int customerId);
    IEnumerable<OrderRepo> GetAll();
    object GetById(int id);
    //void UpdateOrder(OrderRepo order);
    //void DeleteOrder(int orderId);
}
