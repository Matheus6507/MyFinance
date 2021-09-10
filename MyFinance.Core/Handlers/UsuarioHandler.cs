using Microsoft.Extensions.Options;
using MyFinance.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core.Handlers
{
    public class UsuarioHandler : BaseHandler<Usuario>
    {
        public UsuarioHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.Usuarios) 
        { }
    }
}
