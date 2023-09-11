using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FootColorValidator : AbstractValidator<FootColor>
    {
        public FootColorValidator()
        {
            RuleFor(f => f.Name).NotEmpty();
            RuleFor(f => f.Code).NotEmpty();
        }
    }
}
