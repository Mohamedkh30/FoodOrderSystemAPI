namespace FoodOrderSystemAPI.DAL;

public class OrderRepo : EntityRepo<OrderModel>, IOrderRepo
{
    private readonly SystemContext _dbContext;

    public OrderRepo(SystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;

    }

}
