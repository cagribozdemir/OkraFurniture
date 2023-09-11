using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FootValidator : AbstractValidator<Foot>
    {
        public FootValidator() 
        {
            RuleFor(f => f.Name).NotEmpty();
            RuleFor(f => f.Code).NotEmpty();
        }
    }
}
