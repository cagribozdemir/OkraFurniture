using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Product
{
    public class CreateProductDto : IDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Piece { get; set; }
        public int CategoryId { get; set; }
        public bool IsKaputhane { get; set; }
    }
}
