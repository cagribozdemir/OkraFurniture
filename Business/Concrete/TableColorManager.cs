using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs.Category;
using Entity.DTOs.TableColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TableColorManager : ITableColorService
    {
        ITableColorDal _tableColorDal;

        public TableColorManager(ITableColorDal tableColorDal)
        {
            _tableColorDal = tableColorDal;
        }

        public IResult Add(CreateTableColorDto createTableColorDto)
        {
            TableColor tableColor = new TableColor();

            tableColor.Name = createTableColorDto.Name;
            tableColor.Code = createTableColorDto.Code;
            tableColor.Status = true;

            _tableColorDal.Add(tableColor);

            return new SuccessResult(Messages.TableColorAdded);
        }

        public void Delete(int id)
        {
            TableColor tableColor = _tableColorDal.Get(t => t.Id == id);
            _tableColorDal.Delete(tableColor);
        }

        public List<TableColor> GetAll()
        {
            return _tableColorDal.GetAll();
        }

        public TableColor GetById(int id)
        {
            return _tableColorDal.Get(t => t.Id == id);
        }

        public IResult Update(TableColor tableColor)
        {
            _tableColorDal.Update(tableColor);
            return new SuccessResult(Messages.TableColorUpdated);
        }
    }
}
