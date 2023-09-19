using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Fabric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFabricService
    {
        List<Fabric> GetAll();
        Fabric GetById(int? id);
        IResult Add(CreateFabricDto createFabricDto);
        IResult Update(Fabric fabric);
        void Delete(int id);
    }
}
