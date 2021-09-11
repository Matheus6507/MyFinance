using AutoMapper;
using Microsoft.Extensions.Options;
using MyFinance.Core.Models;
using MyFinance.ResponseModels;
using MyFinance.Tools;
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
                cfg.CreateMap<Usuario, UsuarioBorder>().ForMember(dest => dest.Chave, opt => opt.MapFrom(src => src.Uid));
                cfg.CreateMap<UsuarioBorder, Usuario>().ForMember(dest => dest.Uid, opt => opt.MapFrom(src => src.Chave));
                cfg.CreateMap<List<UsuarioBorder>, List<Usuario>>();
            });

            _mapper = _configuration.CreateMapper();
        }

        public List<UsuarioBorder> Listar()
        {
            try
            {
                return _mapper.Map(GetList(), new List<UsuarioBorder>());
            }
            catch (Exception ex)
            {
                throw new MyFinanceException(ex);
            }
        }

        public Usuario GetByEmail(string email)
        {
            try
            {
                return _context.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new MyFinanceException(ex);
            }
        }
        
        public Usuario GetByCPF(string cpf)
        {
            try
            {
                return _context.Usuarios.Where(u => u.CPF == cpf).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new MyFinanceException(ex);
            }
        }

        public UsuarioBorder Cadastrar(UsuarioBorder usuario)
        {
            try
            {
                var user = _mapper.Map<Usuario>(usuario);
                var originalPassword = StringHandler.GetRandomAlphanumericString();

                user.CPF = StringHandler.RemoverFormatacaoCPFCNPJ(user.CPF);
                user.Senha = EncryptionHandler.Encrypt(originalPassword, "Senha");
                user.DataCadastro = DateTime.Now;
                user.Ativo = true;

                return _mapper.Map<UsuarioBorder>(Criar(user));
            }
            catch (Exception ex)
            {
                throw new MyFinanceException(ex);
            }
        }

        public bool Delete(UsuarioBorder usuario)
        {
            try
            {
                var user = Get(usuario.Chave);

                if (user == null)
                    user = GetByEmail(usuario.Email);
                
                if (user == null)
                    user = GetByCPF(usuario.CPF);

                if (user != null)
                {
                    Delete(user);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new MyFinanceException(ex);
            }
        }

        public UsuarioBorder Atualizar(UsuarioBorder usuario)
        {
            try
            {
                var user = _mapper.Map<Usuario>(usuario);
                var savedUser = _context.Usuarios.Where(u => u.Email == user.Email || u.Uid == user.Uid || u.CPF == user.CPF).FirstOrDefault();

                if (savedUser != null)
                {
                    savedUser.Nome = user.Nome;
                    savedUser.CPF = string.IsNullOrEmpty(user.CPF) ? savedUser.CPF : StringHandler.RemoverFormatacaoCPFCNPJ(user.CPF);
                    savedUser.DataNascimento = user.DataNascimento <= DateTime.MinValue ? savedUser.DataNascimento : user.DataNascimento;
                    savedUser.Email = user.Email;

                    Update(savedUser);
                    return _mapper.Map<UsuarioBorder>(savedUser);
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new MyFinanceException(ex);
            }
        }
    }
}
