using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.FabricColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FabricColorManager : IFabricColorService
    {
        IFabricColorDal _fabricColorDal;

        public FabricColorManager(IFabricColorDal fabricColorDal)
        {
            _fabricColorDal = fabricColorDal;
        }

        public void Add(CreateFabricColorDto createFabricColorDto)
        {
            FabricColor fabricColor = new FabricColor();

            fabricColor.Name = createFabricColorDto.Name;
            fabricColor.Code = createFabricColorDto.Code;
            fabricColor.Status = true;

            _fabricColorDal.Add(fabricColor);
        }

        public void Delete(int id)
        {
            FabricColor fabricColor = _fabricColorDal.Get(f => f.Id == id);
            _fabricColorDal.Delete(fabricColor);
        }

        public List<FabricColor> GetAll()
        {
            return _fabricColorDal.GetAll();
        }

        public FabricColor GetById(int id)
        {
            return _fabricColorDal.Get(c => c.Id == id);
        }

        public void Update(FabricColor fabricColor)
        {
            _fabricColorDal.Update(fabricColor);
        }

    }
}
