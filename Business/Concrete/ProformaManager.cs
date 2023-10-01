using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.Order;
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
            proforma.Description = createProformaDto.Description;
            proforma.Date = DateTime.Now;
            proforma.Payment = 0;
            proforma.TotalPrice = 0;
            proforma.Balance = 0;
            proforma.Process = 1;
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
            return MapProformaToResultDto(_proformaDal.GetAll());
        }

        public List<ResultProformaDto> GetAllByProcess(int process)
        {
            return MapProformaToResultDto(_proformaDal.GetAll(p => p.Process == process));
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
            proforma.Payment = result.Payment;
            proforma.Description = result.Description;
            proforma.Date = DateTime.Now;
            proforma.Balance = result.TotalPrice - result.Payment;
            _proformaDal.Update(proforma);

            return new SuccessResult(Messages.ProformaUpdated);
        }

        public void UpdateTotalPrice(int id, decimal totalPrice)
        {
            var proforma = _proformaDal.Get(p => p.Id == id);
            proforma.TotalPrice += totalPrice;
            _proformaDal.Update(proforma);
        }

        private List<ResultProformaDto> MapProformaToResultDto(List<Proforma> proformas)
        {
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
                resultProformaDto.Payment = proforma.Payment;
                resultProformaDto.Balance = proforma.Balance;
                resultProformaDto.Description = proforma.Description;

                if (proforma.Process == 1)
                {
                    resultProformaDto.Process = "İşleme Alındı";
                }
                else if (proforma.Process == 2)
                {
                    resultProformaDto.Process = "Kısmı İşlemde";
                }
                else
                {
                    resultProformaDto.Process = "Tamamlandı";
                }

                resultProformaDtos.Add(resultProformaDto);
            }
            return resultProformaDtos;
        }
    }
}
