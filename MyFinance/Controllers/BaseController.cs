using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFinance.Core;
using MyFinance.Core.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly ApplicationDbContext _context;
        protected HandlerFactory _handlerFactory;
        protected IOptions<Config> _config;

        public BaseController(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory)
        {
            _context = context;
            _handlerFactory = handlerFactory;
            _config = config;
        }
    }
}
