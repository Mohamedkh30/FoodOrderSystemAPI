namespace FoodOrderSystemAPI.DAL;

public class ProductRepo : EntityRepo<ProductModel>, IProductRepo
{
    public ProductRepo(SystemContext dbContext) : base(dbContext)
    {
    }
}
