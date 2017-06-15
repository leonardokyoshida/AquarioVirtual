using AquarioVirtual.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.Domain.Services.CategoriaServices
{
    public interface ICriarCategoriaApplicationService
    {
        Categoria CriarCategoria(Categoria categoria);
    }
}
