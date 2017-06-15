using AquarioVirtual.Domain.Model;
using AquarioVirtual.Web.Application.Services;
using System;
using System.Web.Http;
using AquarioVirtual.Domain.Interfaces;
using AquarioVirtual.WebAPI.Models;
using System.Collections.Generic;

namespace AquarioVirtual.WebAPI.Controllers
{
    public class CategoriaController : BaseController
    {
        private ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            this._categoriaRepository = categoriaRepository;
        }

        [Route("CadastrarNovaCategoria")]
        public CategoriaViewModel CadastrarNovaCategoria([FromBody]CategoriaViewModel cadCategoria)
        {
            var categoriaNova = new Categoria();
            categoriaNova.Id = cadCategoria.Id;
            categoriaNova.Descricao = cadCategoria.Descricao;

            categoriaNova = new CategoriaApplicationService(_categoriaRepository).CriarCategoria(categoriaNova);

            return new CategoriaViewModel(categoriaNova);
        }

        [Route("ObterCategorias")]
        [HttpGet]
        public List<CategoriaViewModel> ObterCategorias()
        {
            List<CategoriaViewModel> categorias = new List<CategoriaViewModel>();
            foreach (var categoria in new CategoriaApplicationService(_categoriaRepository).ObterCategorias())
            {
                categorias.Add(new CategoriaViewModel(categoria));
            }

            return categorias;
        }
    }
}