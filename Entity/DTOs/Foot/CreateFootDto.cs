using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Foot
{
    public class CreateFootDto : IDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
