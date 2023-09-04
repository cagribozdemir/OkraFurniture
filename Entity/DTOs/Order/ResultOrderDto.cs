using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Order
{
    public class ResultOrderDto : IDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductName { get; set; }
        public string FabricName { get; set; }
        public string ProductColorName { get; set; }
        public string FootName { get; set; }
        public string FootColorName { get; set; }
        public string FabricColorName { get; set; }
        public int ProformaId { get; set; }
        public bool Status { get; set; }
    }
}
