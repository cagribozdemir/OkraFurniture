﻿using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.FootColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFootColorService
    {
        List<FootColor> GetAll();
        FootColor GetById(int? id);
        IResult Add(CreateFootColorDto createFootColorDto);
        IResult Update(FootColor footColor);
        void Delete(int id);
    }
}
