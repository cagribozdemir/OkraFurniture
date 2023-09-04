using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Foot;
using Entity.DTOs.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FootManager : IFootService
    {
        IFootDal _footDal;

        public FootManager(IFootDal footDal)
        {
            _footDal = footDal;
        }

        public void Add(CreateFootDto createFootDto)
        {
            Foot foot = new Foot();

            foot.Name = createFootDto.Name;
            foot.Code = createFootDto.Code;
            foot.Status = true;

            _footDal.Add(foot);

            //return new SuccessResult(Messages.FootAdded);
        }

        public void Delete(int id)
        {
            Foot foot = _footDal.Get(f => f.Id == id);
            _footDal.Delete(foot);
            //return new SuccessResult(Messages.FootDeleted);
        }

        public List<Foot> GetAll()
        {
            return _footDal.GetAll();
            //return new SuccessDataResult<List<Foot>>(_footDal.GetAll(), Messages.FootListed);
        }

        public Foot GetById(int id)
        {
            return _footDal.Get(c => c.Id == id);
            //return new SuccessDataResult<Foot>(_footDal.Get(c => c.Id == id));
        }

        public void Update(Foot foot)
        {
            _footDal.Update(foot);

            //return new SuccessResult(Messages.FootUpdated);
        }
    }
}
