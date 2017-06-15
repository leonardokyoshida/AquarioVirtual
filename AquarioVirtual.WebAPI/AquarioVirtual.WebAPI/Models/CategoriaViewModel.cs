using AquarioVirtual.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AquarioVirtual.WebAPI.Models
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(Categoria categoria)
        {
            if (categoria == null)
                return;

            this.Id = categoria.Id;
            this.Descricao = categoria.Descricao;
        }
        public string Id { get; set; }
        public string Descricao { get; set; }
    }
}