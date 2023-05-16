namespace FoodOrderSystemAPI;

public class OrderProductRepo : EntityRepo<OrderProductModel>, IOrderProductRepo
{
    public OrderProductRepo(SystemContext dbContext) : base(dbContext)
    {
    }
}
