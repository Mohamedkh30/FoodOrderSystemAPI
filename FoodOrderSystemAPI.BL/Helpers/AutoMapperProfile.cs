using AutoMapper;
using FoodOrderSystemAPI.DAL;

namespace FoodOrderSystemAPI.BL;

public class AutoMapperProfile: Profile
{
    AutoMapperProfile()
    {
        #region ReviewModel mappings
        // inputs
        CreateMap<AddReviewInputDto, ReviewModel>();
        CreateMap<UpdateReviewInputDto, ReviewModel>();
        // outputs
        CreateMap<ReviewModel, AddReviewOutputDto>();
        CreateMap<ReviewModel, GetAllReveiwsOutputDto>();
        CreateMap<ReviewModel, GetReviewOutputDto>();

        #endregion
    }
}
