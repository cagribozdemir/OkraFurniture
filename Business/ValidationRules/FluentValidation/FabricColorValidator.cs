using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FabricColorValidator : AbstractValidator<FabricColor>
    {
        public FabricColorValidator() 
        {
            RuleFor(f => f.Name).NotEmpty();
            RuleFor(f => f.Code).NotEmpty();
        }
    }
}
