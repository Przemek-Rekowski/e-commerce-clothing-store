﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.Dtos
{
    public class SizeDto
    {
        public string Value { get; set; } = default!;
        public bool IsAvalible { get; set; }
    }
}
