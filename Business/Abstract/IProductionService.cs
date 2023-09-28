using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductionService
    {
        List<Production> GetAll();
        Production GetById(int id);
        IResult Add(CreateProductionDto createProductionDto);
        IResult Update(Production production);
        void Delete(int id);

        
    }
}
