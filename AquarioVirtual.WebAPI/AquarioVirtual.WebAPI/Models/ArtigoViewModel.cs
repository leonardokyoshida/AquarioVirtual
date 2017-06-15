using AquarioVirtual.Domain.Enums;
using AquarioVirtual.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquarioVirtual.WebAPI.Models
{
    public class ArtigoViewModel
    {
        public ArtigoViewModel(Artigo artigo)
        {
            if (artigo == null)
                return;
            this.Id = artigo.Id;
            this.Texto = artigo.Texto;
            //this.CategoriaId = artigo.CategoriaId;
            this.Categoria = artigo.Categoria;
            this.DataPublicacao = artigo.DataPublicacao;
            this.Fotos = artigo.Fotos;
            //this.UsuarioId = artigo.UsuarioId;
            this.Usuario = artigo.Usuario;
            //this.PeixeId = artigo.PeixeId;
            this.Peixe = artigo.Peixe;
            this.Status = EnumHelper.GetDescription(artigo.Status); 
        }
        public string Id { get; set; }
        public string Texto { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public IEnumerable<string> Fotos { get; set; }
        public Usuario Usuario { get; set; }
        public Peixe Peixe { get; set; }
        public string Status { get; set; }

        //public string CategoriaId { get; set; }
        //public string UsuarioId { get; set; }
        //public string PeixeId { get; set; }
    }
}