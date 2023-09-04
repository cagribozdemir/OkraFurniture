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
            proforma.ReceiptNo = createProformaDto.ReceiptNo;
            proforma.TotalPrice = createProformaDto.TotalPrice;
            proforma.Date = DateTime.Now;
            proforma.Status = true;

            _proformaDal.Add(proforma);
            
            //return new SuccessResult(Messages.ProformaAdded);
        }

        public void Delete(int id)
        {
            Proforma proforma = _proformaDal.Get(p => p.Id == id);
            _proformaDal.Delete(proforma);
            //return new SuccessResult(Messages.ProformaDeleted);
        }

        public List<Proforma> GetAll()
        {
            return _proformaDal.GetAll();
            //return new SuccessDataResult<List<Proforma>>(_proformaDal.GetAll(), Messages.ProformaListed);
        }

        public Proforma GetById(int id)
        {
            return _proformaDal.Get(c => c.Id == id);
            //return new SuccessDataResult<Proforma>(_proformaDal.Get(c => c.Id == id));
        }

        public void Update(Proforma proforma)
        {
            Proforma findProforma = _proformaDal.Get(p => p.Id == proforma.Id);

            findProforma.CompanyName = proforma.CompanyName;
            findProforma.Address = proforma.Address;
            findProforma.ReceiptNo = proforma.ReceiptNo;
            findProforma.TotalPrice = proforma.TotalPrice;
            findProforma.Date = DateTime.Now;

            _proformaDal.Update(findProforma);
            
            //return new SuccessResult(Messages.ProformaUpdated);
        }
    }
}
