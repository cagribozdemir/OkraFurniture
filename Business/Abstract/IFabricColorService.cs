using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.FabricColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFabricColorService
    {
        List<FabricColor> GetAll();
        FabricColor GetById(int id);
        void Add(CreateFabricColorDto createFabricColorDto);
        void Update(FabricColor fabricColor);
        void Delete(int id);
    }
}
