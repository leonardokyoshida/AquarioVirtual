using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.App.Models
{
    public class Artigo
    {
        public string Id { get; set; }
        public string Texto { get; set; }
        public string CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public IEnumerable<string> Fotos { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string PeixeId { get; set; }
        public Peixe Peixe { get; set; }
        public string Status { get; set; }

        public string Slug
        {
            get
            {
                return Fotos?.FirstOrDefault();
            }
        }
    }
}
