namespace FoodOrderSystemAPI.DAL;

public interface IOrderRepo: IEntityRepo<OrderModel>
{
    //void CreateOrder(OrderRepo order);
    //OrderRepo GetOrderById(int orderId);
    List<OrderModel> GetOrdersByCustomerId(int customerId);
    IEnumerable<OrderRepo> GetAll();
    object GetById(int id);
    //void UpdateOrder(OrderRepo order);
    //void DeleteOrder(int orderId);
}
