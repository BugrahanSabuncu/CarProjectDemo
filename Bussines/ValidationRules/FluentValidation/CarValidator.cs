using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice > 0);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ModelYear > 1995);
        }
    }
}
