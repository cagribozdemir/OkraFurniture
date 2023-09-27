using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Kaynakhane;
using Entity.DTOs.Production;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductionManager : IProductionService
    {
        IProductionDal _productionDal;

        public ProductionManager(IProductionDal productionDal)
        {
            _productionDal = productionDal;
        }

        public IResult Add(CreateProductionDto createProductionDto)
        {
            Production production = new Production();

            production.Name = createProductionDto.Name;
            production.Status = true;

            _productionDal.Add(production);

            return new SuccessResult();
        }

        public void Delete(int id)
        {
            Production production = _productionDal.Get(p => p.Id == id);
            _productionDal.Delete(production);
        }

        public List<Production> GetAll()
        {
            return _productionDal.GetAll();
        }

        public Production GetById(int id)
        {
            return _productionDal.Get(p => p.Id == id);
        }

        public IResult Update(Production production)
        {
            _productionDal.Update(production);
            return new SuccessResult();
        }
    }
}
