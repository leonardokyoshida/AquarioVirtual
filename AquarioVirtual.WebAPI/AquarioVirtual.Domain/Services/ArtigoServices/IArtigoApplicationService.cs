using AquarioVirtual.Domain.Commands;
using AquarioVirtual.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.Domain.Services.ArtigosServices
{
    public interface IArtigoApplicationService
    {
        Artigo CriarArtigo(Artigo artigo);

        List<Artigo> ObterUltimosArtigos();

        Artigo ObterArtigo(string id);

        void RemoverArtigo(Artigo artigo);

        List<Artigo> PesquisarArtigo(string filter);
    }
}
