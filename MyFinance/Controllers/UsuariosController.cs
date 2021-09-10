using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFinance.Core;
using MyFinance.Core.Handlers;
using MyFinance.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : BaseController
    {
        public UsuariosController(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base (context, config, handlerFactory) 
        { }

        [HttpGet]
        public List<UsuarioResponse> Get()
        {
            return _handlerFactory.Usuario.Listar();
        }
    }
}
