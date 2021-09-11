using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Tools
{
    public static class ExceptionHandler
    {
    }

    public class MyFinanceException : Exception
    {
        public MyFinanceException(string message) : base(message)
        {
            //Exceção gerada por nós mesmo, não faz nada
        }

        public MyFinanceException(Exception ex) : base(ex.Message)
        {
            if (ex.GetType() != typeof(MyFinanceException))
            {
                throw new MyFinanceException(Constantes.msgErroGeral);
            }
        }
    }
}
