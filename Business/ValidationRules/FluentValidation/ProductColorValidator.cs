using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductColorValidator : AbstractValidator<ProductColor>
    {
        public ProductColorValidator() 
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Code).NotEmpty();
        }
    }
}
