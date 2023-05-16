namespace FoodOrderSystemAPI;

public class CustomerRepo : EntityRepo<CustomerModel>, ICustomerRepo
{
    public CustomerRepo(SystemContext dbContext) : base(dbContext)
    {
    }
}

