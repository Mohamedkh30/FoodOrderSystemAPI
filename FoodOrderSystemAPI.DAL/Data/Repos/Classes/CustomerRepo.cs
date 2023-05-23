namespace FoodOrderSystemAPI.DAL;

public class CustomerRepo : EntityRepo<CustomerModel>, ICustomerRepo
{
    public CustomerRepo(SystemContext dbContext) : base(dbContext)
    {
    }

    public void CancelOrder()
    {
        
    }

    public void Login()
    {
        throw new NotImplementedException();
    }

    public int MakeOrder()
    {
        throw new NotImplementedException();
    }

    public void Pay()
    {
        throw new NotImplementedException();
    }

    public void RateProduct()
    {
        throw new NotImplementedException();
    }

    public void Register()
    {
      
    }
}

