using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Proforma
{
    public class UpdateProformaDto : IDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string ReceiptNo { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
