using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
    #region CTOR & Fields

    private IReviewManager _reviewManager;

    public ReviewController(IReviewManager reviewManager)
    {
        _reviewManager = reviewManager;
    }
    #endregion

    [HttpGet]
    public ActionResult<List<GetAllReveiwsOutputDto>> GetAll()
    {
        return _reviewManager.GetAll();
    }
}
