using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Order
{
    public class UpdateOrderDto : IDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int FabricId { get; set; }
        public int ProductColorId { get; set; }
        public int FootId { get; set; }
        public int FootColorId { get; set; }
        public int FabricColorId { get; set; }
        public int ProformaId { get; set; }
    }
}
