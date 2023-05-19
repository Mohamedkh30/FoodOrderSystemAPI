namespace FoodOrderSystemAPI.DAL;

public class RestaurantRepo : EntityRepo<RestaurantModel>, IRestaurantRepo
{
    public RestaurantRepo(SystemContext dbContext) : base(dbContext)
    {
    }
}
