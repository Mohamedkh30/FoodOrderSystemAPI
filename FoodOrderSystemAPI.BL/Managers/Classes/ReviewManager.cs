using AutoMapper;
using FoodOrderSystemAPI.DAL;

namespace FoodOrderSystemAPI.BL;

public class ReviewManager : IReviewManager
{
    #region Feilds & CTOR
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public ReviewManager(IUnitOfWork unit, IMapper mapper)
    {
        _unit = unit;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public AddReviewOutputDto Add(AddReviewInputDto inputDto)
    {
        var ToBeAddedReview = _mapper.Map<ReviewModel>(inputDto);
        _unit.Reveiws.Add(ToBeAddedReview);
        _unit.Save();
        var OutputDto = _mapper.Map<AddReviewOutputDto>(ToBeAddedReview);
        return OutputDto;
    }

    public DeleteStatusEnum Delete(DeleteReviewInputDto inputDto)
    {
        var ToBeDeleted = _unit.Reveiws.GetByIds(inputDto.CustomerId, inputDto.ProductId);
        if (ToBeDeleted is null)
            return DeleteStatusEnum.NotFound;
        _unit.Reveiws.Delete(ToBeDeleted);
        _unit.Save();
        return DeleteStatusEnum.Successfull;
    }

    public List<GetAllReveiwsOutputDto> GetAll()
    {
        var AllReviews = _unit.Reveiws.GetAll();
        var Result = _mapper.Map<List<GetAllReveiwsOutputDto>>(AllReviews);
        return Result;
    }

    public GetReviewOutputDto GetByIds(int customerId, int productId)
    {
        var TargetReview = _unit.Reveiws.GetByIds(customerId, productId);
        var Result = _mapper.Map<GetReviewOutputDto>(TargetReview);
        return Result;
    }

    public UpdateStatusEnum Update(UpdateReviewInputDto inputDto)
    {
        var ToBeUpdated = _unit.Reveiws.GetByIds(inputDto.CustomerId, inputDto.ProductId);
        if (ToBeUpdated is null)
            return UpdateStatusEnum.NotFound;
        _mapper.Map(inputDto, ToBeUpdated);
        _unit.Save();
        return UpdateStatusEnum.Successfull;
    }
    #endregion
}
