﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class BaseResponse
    {
        public bool Error { get; set; }
        public string Mensagem { get; set; }
    }
}
