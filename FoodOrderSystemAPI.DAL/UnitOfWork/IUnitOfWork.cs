namespace FoodOrderSystemAPI;

public interface IUnitOfWork: IDisposable
{
    IAdminRepo Admins { get; }
    ICustomerRepo Customers { get; }
    IOrderRepo Orders { get; }
    IOrderProductRepo OrdersProducts { get; }
    IProductRepo Products { get; }
    IReviewRepo Reveiws { get; }
    IRestaurantRepo Restaurants { get; }

    int Save();
}
