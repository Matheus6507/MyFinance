using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core
{
    public class Config : IOptions<Config>
    {
        public string UserIP { get; set; }
        public Config Value { get { return this; } }
    }
}
