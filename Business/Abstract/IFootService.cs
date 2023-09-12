using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Foot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFootService
    {
        List<Foot> GetAll();
        Foot GetById(int id);
        IResult Add(CreateFootDto createFootDto);
        IResult Update(Foot foot);
        void Delete(int id);
    }
}
