using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFinance.Core;
using MyFinance.Core.Handlers;
using MyFinance.Models;
using MyFinance.ResponseModels;
using MyFinance.Tools;
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
        public UsuariosController(ApplicationDbContext context, IOptions<Config> config, HandlerFactory handlerFactory) : base(context, config, handlerFactory)
        { }

        [HttpGet]
        public UsersResponse Get()
        {
            try
            {
                return new UsersResponse()
                {
                    Error = false,
                    Usuarios = _handlerFactory.Usuario.Listar()
                };
            }
            catch (Exception ex)
            {
                return new UsersResponse { Error = true, Mensagem = new MyFinanceException(ex).Message };
            }
        }

        [HttpPost]
        public UsersResponse Post(UsuarioBorder usuario)
        {
            try
            {
                var user = _handlerFactory.Usuario.Cadastrar(usuario);

                return new UsersResponse
                {
                    Error = false,
                    Mensagem = Constantes.msgUsuarioCadastradoSucesso,
                    Usuarios = new List<UsuarioBorder> { user }
                };
            }
            catch (Exception ex)
            {
                return new UsersResponse { Error = true, Mensagem = new MyFinanceException(ex).Message };
            }
        }

        [HttpDelete]
        public BaseResponse Delete(UsuarioBorder user)
        {
            try
            {
                string error = string.Empty;

                if (user.Chave == Guid.Empty)
                    if (string.IsNullOrEmpty(user.Email))
                        if (string.IsNullOrEmpty(user.CPF))
                            error = Constantes.msgSemDadosParaLocalizarUsuario;

                if (string.IsNullOrEmpty(error) && _handlerFactory.Usuario.Delete(user))
                {
                    return new BaseResponse
                    {
                        Error = false,
                        Mensagem = Constantes.msgUsuarioDeletadoSucesso
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        Error = true,
                        Mensagem = string.IsNullOrEmpty(error) ? Constantes.msgSemDadosParaLocalizarUsuario : error
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse { Error = true, Mensagem = new MyFinanceException(ex).Message };
            }
        }

        [HttpPut]
        public UsersResponse Put(UsuarioBorder usuario)
        {
            try
            {
                string error = string.Empty;

                if (usuario.Chave == Guid.Empty)
                    if (string.IsNullOrEmpty(usuario.Email))
                        if (string.IsNullOrEmpty(usuario.CPF))
                            error = Constantes.msgSemDadosParaLocalizarUsuario;

                var user = _handlerFactory.Usuario.Atualizar(usuario);

                if (user != null)
                {
                    return new UsersResponse
                    {
                        Error = false,
                        Mensagem = Constantes.msgUsuarioAtualizadoComSucesso,
                        Usuarios = new List<UsuarioBorder> { user }
                    };
                }
                else
                {
                    return new UsersResponse
                    {
                        Error = true,
                        Mensagem = Constantes.msgUsuarioNaoEncontrado
                    };
                }
            }
            catch (Exception ex)
            {
                return new UsersResponse { Error = true, Mensagem = new MyFinanceException(ex).Message };
            }
        }
    }
}
