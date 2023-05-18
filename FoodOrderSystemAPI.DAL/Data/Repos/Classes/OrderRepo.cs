namespace FoodOrderSystemAPI.DAL;

public class OrderRepo : EntityRepo<OrderModel>, IOrderRepo
{
    private readonly SystemContext _dbContext;

    public OrderRepo(SystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;

    }


    //public void CreateOrder(OrderRepo order)
    //{   
    //    _dbContext.Set<OrderRepo>().Add(order);
    //    _dbContext.SaveChanges();
    //}

    //public void DeleteOrder(int orderId)
    //{

    //    var order = _dbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
    //    if (order != null)
    //    {
    //        _dbContext.Orders.Remove(order);
    //        _dbContext.SaveChanges();
    //    }
    //}

    //public OrderRepo? GetOrderById(int orderId)
    //{
    //    //return _dbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
    //    return _dbContext.Set<OrderRepo>().Find(orderId);

    //}

    //public List<OrderModel> GetOrdersByCustomerId(int customerId)
    //{
    //    return _dbContext.Orders.Where(o => o.CustomerId == customerId).ToList();     //old but id if it works or not
    //}

    public List<OrderModel> GetOrdersByCustomerId(int customerId)          //Generic
    {
        return Search(o => o.CustomerId == customerId).ToList();
    }

    IEnumerable<OrderRepo> IOrderRepo.GetAll()
    {
        throw new NotImplementedException();
    }

    object IOrderRepo.GetById(int id)
    {
        throw new NotImplementedException();
    }



    //public void UpdateOrder(OrderRepo order)
    //{
    //    _dbContext.Set<OrderRepo>().Update(order);
    //    _dbContext.SaveChanges();
    //}
}
