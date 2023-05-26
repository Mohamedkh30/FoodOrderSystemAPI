using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public class AddReviewOutputDtoValidator : AbstractValidator<AddReviewOutputDto>
{
    public AddReviewOutputDtoValidator()
    {
        
    }
}
