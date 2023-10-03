using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Proforma : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string ReceiptNo { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Payment { get; set; }
        public decimal Balance { get; set; }
        public string? Description { get; set; }
        public int Process { get; set; }
        public bool Status { get; set; }
        public List<Order> Orders { get; set; }
    }
}
