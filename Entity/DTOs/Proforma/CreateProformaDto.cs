using Core.Entities;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Proforma
{
    public class CreateProformaDto : IDto
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ReceiptNo { get; set; }
        public string Description { get; set; }
    }
}
