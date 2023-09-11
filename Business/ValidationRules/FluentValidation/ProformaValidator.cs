using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProformaValidator : AbstractValidator<Proforma>
    {
        public ProformaValidator() 
        {
            RuleFor(p => p.Address).NotEmpty();
        }
    }
}
