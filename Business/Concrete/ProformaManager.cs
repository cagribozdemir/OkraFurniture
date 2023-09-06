using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Proforma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProformaManager : IProformaService
    {
        IProformaDal _proformaDal;

        public ProformaManager(IProformaDal proformaDal)
        {
            _proformaDal = proformaDal;
        }
        public void Add(CreateProformaDto createProformaDto)
        {
            Proforma proforma = new Proforma();

            proforma.CompanyName = createProformaDto.CompanyName;
            proforma.Address = createProformaDto.Address;
            proforma.ReceiptNo = "U152";
            proforma.TotalPrice = 0;
            proforma.Date = DateTime.Now;
            proforma.Status = true;

            _proformaDal.Add(proforma);
        }

        public void Delete(int id)
        {
            Proforma proforma = _proformaDal.Get(p => p.Id == id);
            _proformaDal.Delete(proforma);
        }

        public List<Proforma> GetAll()
        {
            return _proformaDal.GetAll();
        }

        public Proforma GetById(int id)
        {
            return _proformaDal.Get(c => c.Id == id);
        }

        public void Update(Proforma proforma)
        {
            _proformaDal.Update(proforma);
        }
    }
}
