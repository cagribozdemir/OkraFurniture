using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Fabric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FabricManager : IFabricService
    {
        IFabricDal _fabricDal;

        public FabricManager(IFabricDal fabricDal)
        {
            _fabricDal = fabricDal;
        }

        public void Add(CreateFabricDto createFabricDto)
        {
            Fabric fabric = new Fabric();

            fabric.Name = createFabricDto.Name;
            fabric.Code = createFabricDto.Code;
            fabric.Status = true;

            _fabricDal.Add(fabric);
        }

        public void Delete(int id)
        {
            Fabric fabric = _fabricDal.Get(f => f.Id == id);
            _fabricDal.Delete(fabric);
        }

        public List<Fabric> GetAll()
        {
            return _fabricDal.GetAll();
        }

        public Fabric GetById(int id)
        {
            return _fabricDal.Get(c => c.Id == id);
        }

        public void Update(Fabric fabric)
        {
            _fabricDal.Update(fabric);
        }
    }
}
