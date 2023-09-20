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
        public IResult Add(CreateProformaDto createProformaDto)
        {
            Proforma proforma = new Proforma();

            proforma.CompanyName = createProformaDto.CompanyName;
            proforma.Address = createProformaDto.Address;
            proforma.ReceiptNo = createProformaDto.ReceiptNo;
            proforma.TotalPrice = 0;
            proforma.Date = DateTime.Now;
            proforma.Status = true;

            _proformaDal.Add(proforma);

            return new SuccessResult(Messages.ProformaAdded);
        }

        public void Delete(int id)
        {
            Proforma proforma = _proformaDal.Get(p => p.Id == id);
            _proformaDal.Delete(proforma);
        }

        public List<ResultProformaDto> GetAll()
        {
            List<Proforma> proformas = _proformaDal.GetAll();
            List<ResultProformaDto> resultProformaDtos = new List<ResultProformaDto>();
            foreach (var proforma in proformas)
            {
                ResultProformaDto resultProformaDto = new ResultProformaDto();
                resultProformaDto.Id = proforma.Id;
                resultProformaDto.ReceiptNo = proforma.ReceiptNo;
                resultProformaDto.CompanyName = proforma.CompanyName;
                resultProformaDto.Address = proforma.Address;
                resultProformaDto.Date = proforma.Date;
                resultProformaDto.TotalPrice = proforma.TotalPrice;

                resultProformaDtos.Add(resultProformaDto);
            }
            return resultProformaDtos;
        }

        public Proforma GetById(int id)
        {
            return _proformaDal.Get(p => p.Id == id);
        }

        public IResult Update(Proforma proforma)
        {
            var result = _proformaDal.Get(p => p.Id == proforma.Id);
            proforma.ReceiptNo = result.ReceiptNo;
            proforma.TotalPrice = result.TotalPrice;
            proforma.Date = DateTime.Now;
            _proformaDal.Update(proforma);

            return new SuccessResult(Messages.ProformaUpdated);
        }

        public void UpdateTotalPrice(int id, decimal totalPrice)
        {
            var proforma = _proformaDal.Get(p => p.Id == id);
            proforma.TotalPrice += totalPrice;
            _proformaDal.Update(proforma);
        }
    }
}
