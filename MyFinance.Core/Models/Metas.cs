using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core.Models
{
    public class Metas
    {
        public Guid Uid { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal Objetivo { get; set; }
        public Guid UidUsuario { get; set; }
    }
}
