﻿using Business.Abstract;
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
        public void Add(CreateFootColorDto createFootColorDto)
        {
            FootColor footColor = new FootColor();

            footColor.Name = createFootColorDto.Name;
            footColor.Code = createFootColorDto.Code;
            footColor.Status = true;

            _footColorDal.Add(footColor);

            //return new SuccessResult(Messages.FootColorAdded);
        }

        public void Delete(int id)
        {
            FootColor footColor = _footColorDal.Get(f => f.Id == id);
            _footColorDal.Delete(footColor);
            //return new SuccessResult(Messages.FootColorDeleted);
        }

        public List<FootColor> GetAll()
        {
            return _footColorDal.GetAll();
            //return new SuccessDataResult<List<FootColor>>(_footColorDal.GetAll(), Messages.FootColorListed);
        }

        public FootColor GetById(int id)
        {
            return _footColorDal.Get(c => c.Id == id);
            //return new SuccessDataResult<FootColor>(_footColorDal.Get(c => c.Id == id));
        }

        public void Update(FootColor footColor)
        {
            _footColorDal.Update(footColor);

            //return new SuccessResult(Messages.FootColorUpdated);
        }
    }
}