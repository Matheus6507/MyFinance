using MyFinance.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class UsersResponse : BaseResponse
    {
        public List<UsuarioBorder> Usuarios { get; set; }
    }
}
