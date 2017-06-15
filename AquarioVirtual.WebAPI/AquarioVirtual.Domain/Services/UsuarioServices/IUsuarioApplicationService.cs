using AquarioVirtual.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.Domain.Services.UsuarioServices
{
    public interface IUsuarioApplicationService
    {
        Usuario UsuarioLogado { get; }

        Usuario AutenticarUsuario(string userName, string password);

        Usuario RegistrarUsuario(Usuario usuario);
    }
}
