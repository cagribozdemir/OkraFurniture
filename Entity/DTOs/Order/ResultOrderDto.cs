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
        public decimal Discount { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string? FabricName { get; set; }
        public string ProductColorName { get; set; }
        public string? FootColorName { get; set; }
        public string? FootName { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public string ProductionName { get; set; }
        public string CompanyName { get; set; }
        public int Process { get; set; }
    }
}
