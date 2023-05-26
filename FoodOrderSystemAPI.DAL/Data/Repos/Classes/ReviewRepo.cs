namespace FoodOrderSystemAPI.DAL;

public class ReviewRepo : EntityRepo<ReviewModel>, IReviewRepo
{
    SystemContext _context;
    public ReviewRepo(SystemContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public ReviewModel? GetByIds(int customerId, int productId)
    {
        var result = _context.Set<ReviewModel>().Find(customerId, productId);
        return result;
    }
}
