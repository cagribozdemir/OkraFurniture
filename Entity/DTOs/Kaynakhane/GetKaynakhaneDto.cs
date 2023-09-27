using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Kaynakhane
{
    public class GetKaynakhaneDto : IDto
    {
        public string FootName { get; set; }
        public string FootColorName { get; set; }
        public int Amount { get; set; }
    }
}
