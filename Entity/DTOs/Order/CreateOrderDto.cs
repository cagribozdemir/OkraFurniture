using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Order
{
    public class CreateOrderDto : IDto
    {
        public int Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int? FabricId { get; set; }
        public int ProductColorId { get; set; }
        public int? FootId { get; set; }
        public int? FootColorId { get; set; }
        public int ProformaId { get; set; }
        public string? Description { get; set; }
    }
}
