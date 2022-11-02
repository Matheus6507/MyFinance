using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core.Models
{
    public class Conta
    {
        public Guid Uid { get; set; }
        public string Nome { get; set; }
        public Guid UidUsuario { get; set; }
    }
}
