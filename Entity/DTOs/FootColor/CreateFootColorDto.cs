﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.FootColor
{
    public class CreateFootColorDto : IDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
