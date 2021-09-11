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
                cfg.CreateMap<Usuario, UsuarioResponse>().ForMember(dest => dest.Chave, opt => opt.MapFrom(src => src.Uid));
                cfg.CreateMap<UsuarioResponse, Usuario>().ForMember(dest => dest.Uid, opt => opt.MapFrom(src => src.Chave));
                cfg.CreateMap<List<UsuarioResponse>, List<Usuario>>();
            });

            _mapper = _configuration.CreateMapper();
        }

        public List<UsuarioResponse> Listar()
        {
            try
            {
                return _mapper.Map(GetList(), new List<UsuarioResponse>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
