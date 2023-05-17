namespace FoodOrderSystemAPI.DAL;

public class OrderRepo : EntityRepo<OrderModel>, IOrderRepo
{
    public OrderRepo(SystemContext dbContext) : base(dbContext)
    {
    }
}
