using AquarioVirtual.Domain.Interfaces;
using AquarioVirtual.Domain.Model;
using AquarioVirtual.Web.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AquarioVirtual.WebAPI.Controllers
{
    public class UsuarioController : BaseController
    {
        private IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [Route("ObterUsuarioLogado")]
        [HttpGet]
        public Usuario ObterUsuarioLogado()
        {
            Usuario usuario = new UsuarioApplicationService(_repository).UsuarioLogado;

            return usuario;
        }

        [Route("RegistrarUsuario")]
        public Usuario RegistrarUsuario([FromBody] Usuario usuario)
        {
            return new UsuarioApplicationService(_repository).RegistrarUsuario(usuario);
        }

        [Route("Autenticar")]
        [HttpPost]
        public Usuario Autenticar([FromBody] Usuario usuario)
        {
            return new UsuarioApplicationService(_repository).AutenticarUsuario(usuario.Email, usuario.Senha);
        


        }
    }
}