using AutoMapper;
using Microsoft.Extensions.Options;
using MyFinance.Core.Models;
using MyFinance.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Core.Handlers
{
    public class UsuarioHandler : BaseHandler<Usuario>
    {
        private MapperConfiguration _configuration;
        private IMapper _mapper;

        public UsuarioHandler(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory, context.Usuarios) 
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Usuario, UsuarioResponse>();
                cfg.CreateMap<UsuarioResponse, Usuario>();
                cfg.CreateMap<List<Usuario>, List<UsuarioResponse>>();
            });

            _mapper = _configuration.CreateMapper();
        }

        public List<UsuarioResponse> Listar()
        {
            try
            {
                return _mapper.Map<List<UsuarioResponse>>(GetList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
