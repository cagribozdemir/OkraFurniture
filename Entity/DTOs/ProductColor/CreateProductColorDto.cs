using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.ProductColor
{
    public class CreateProductColorDto : IDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
