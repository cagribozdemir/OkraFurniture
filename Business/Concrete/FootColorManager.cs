using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.FootColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FootColorManager : IFootColorService
    {
        IFootColorDal _footColorDal;

        public FootColorManager(IFootColorDal footColorDal)
        {
            _footColorDal = footColorDal;
        }
        public IResult Add(CreateFootColorDto createFootColorDto)
        {
            FootColor footColor = new FootColor();

            footColor.Name = createFootColorDto.Name;
            footColor.Code = createFootColorDto.Code;
            footColor.Status = true;

            _footColorDal.Add(footColor);

            return new SuccessResult(Messages.FootColorAdded);
        }

        public void Delete(int id)
        {
            FootColor footColor = _footColorDal.Get(f => f.Id == id);
            _footColorDal.Delete(footColor);
        }

        public List<FootColor> GetAll()
        {
            return _footColorDal.GetAll();
        }

        public FootColor GetById(int? id)
        {
            return _footColorDal.Get(c => c.Id == id);
        }

        public IResult Update(FootColor footColor)
        {
            _footColorDal.Update(footColor);

            return new SuccessResult(Messages.FootColorUpdated);
        }
    }
}
