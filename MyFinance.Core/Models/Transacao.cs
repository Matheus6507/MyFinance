using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core.Models
{
    public class Transacao
    {
        public Guid Uid { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public Guid UidConta { get; set; }
        public Guid UidUsuario { get; set; }
    }
}
