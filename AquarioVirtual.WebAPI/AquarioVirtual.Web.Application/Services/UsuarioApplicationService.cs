using AquarioVirtual.Domain.Model;
using AquarioVirtual.Domain.Interfaces;
using AquarioVirtual.Domain.Services.UsuarioServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquarioVirtual.Web.Application.Services
{
    public class UsuarioApplicationService : ApplicationService, IUsuarioApplicationService
    {
        public UsuarioApplicationService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        private readonly IUsuarioRepository _repository;

        public Usuario UsuarioLogado
        {
            get
            {
                var Usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
                if (Usuario == null)
                {
                    return null;
                }
                else
                {
                    return _repository.GetById(Usuario.Value.ToString());
                }
            }
        }

        public Usuario RegistrarUsuario(Usuario usuario)
        {
            return _repository.Add(usuario);
        }

        public Usuario AutenticarUsuario(string userName, string password)
        {

            try
            {
                Usuario RetornoUser = _repository.GetWhere(p => p.Email == userName && p.Senha == password).FirstOrDefault();
                return RetornoUser;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}

