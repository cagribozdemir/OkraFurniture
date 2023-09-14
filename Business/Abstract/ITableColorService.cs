using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.TableColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITableColorService
    {
        List<TableColor> GetAll();
        TableColor GetById(int id);
        IResult Add(CreateTableColorDto createTableColorDto);
        IResult Update(TableColor tableColor);
        void Delete(int id);
    }
}
