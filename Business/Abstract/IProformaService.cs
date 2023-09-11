using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.Proforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProformaService
    {
        List<ResultProformaDto> GetAll();
        Proforma GetById(int id);
        void Add(CreateProformaDto createProformaDto);
        void Delete(int id);
        void Update(Proforma proforma);   
    }
}
