namespace FoodOrderSystemAPI.DAL;

public class RestaurantRepo : EntityRepo<RestaurantModel>, IRestaurantRepo
{
    private readonly SystemContext _dbContext;

    public RestaurantRepo(SystemContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
