namespace FoodOrderSystemAPI;

public interface IUnitOfWork: IDisposable
{
    IAdminRepo Admins { get; }
    ICustomerRepo Customers { get; }
    IOrderRepo Orders { get; }
    IOrderProductRepo OrdersProducts { get; }
    IProductRepo Prducts { get; }
    IReviewRepo Reveiws { get; }
    IRestaurantRepo Restaurants { get; }

    int Save();
}
