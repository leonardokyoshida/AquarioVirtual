using AquarioVirtual.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.Domain.Commands
{
    public class CriarArtigoCommand
    {
        public CriarArtigoCommand(string texto, IObservable<string> fotos, int categoriaId, int usuarioId, int peixeId, StatusArtigo status)
        {
            Texto = texto;
            Fotos = fotos;
            CategoriaId = categoriaId;
            UsuarioId = usuarioId;
            PeixeId = peixeId;
            Status = status;
        }

        public string Texto { get; private set; }

        public IObservable<string> Fotos { get; private set; }

        public int CategoriaId { get; private set; }

        public int UsuarioId { get; private set; }

        public int PeixeId { get; private set; }

        public StatusArtigo Status { get; private set; }

    }
}
