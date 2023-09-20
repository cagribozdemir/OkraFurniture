using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Production
{
    public class CreateProductionDto : IDto
    {
        public string Name { get; set; }
    }
}
