using AquarioVirtual.Domain.Model;
using AquarioVirtual.Web.Application.Services;
using System;
using System.Web.Http;
using AquarioVirtual.Domain.Interfaces;
using AquarioVirtual.WebAPI.Models;
using System.Collections.Generic;

namespace AquarioVirtual.WebAPI.Controllers
{
    public class ArtigoController : BaseController
    {
        private IArtigoRepository _repository;
        private IUsuarioRepository _usuarioRepository;
        private ICategoriaRepository _categoriaRepository;
        private IPeixeRepository _peixeCategory;
        private ArtigoApplicationService _service;

        public ArtigoController(IArtigoRepository repository, IUsuarioRepository usuarioRepository, ICategoriaRepository categoriaRepository, IPeixeRepository peixeRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _categoriaRepository = categoriaRepository;
            _peixeCategory = peixeRepository;
            _service = new ArtigoApplicationService(_repository, _usuarioRepository, _categoriaRepository, _peixeCategory);
        }
        [Route("CadastrarArtigo")]
        public ArtigoViewModel CadastrarArtigo([FromBody]ArtigoViewModel cadArtigo)
        {
            //var artigo = new ArtigoViewModel(new Artigo().New());
            //var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(artigo);
            //cadArtigo = artigo;
            var artigoNovo = InstanciarArtigo(cadArtigo);
            artigoNovo = _service.CriarArtigo(artigoNovo);
            return new ArtigoViewModel(artigoNovo);

        }

        [Route("ObterUltimosArtigos")]
        [HttpGet]
        public List<ArtigoViewModel> ObterUltimosArtigos()
        {
            List<ArtigoViewModel> artigosVm = new List<ArtigoViewModel>();
            foreach (var artigo in _service.ObterUltimosArtigos())
            {
                artigosVm.Add(new ArtigoViewModel(artigo));
            }

            return artigosVm;
        }

        [Route("ObterArtigo")]
        [HttpGet]
        public ArtigoViewModel ObterArtigo([FromUri] string idArtigo)
        {
            return new ArtigoViewModel(_service.ObterArtigo(idArtigo));
        }

        [Route("RemoverArtigo")]
        [HttpPost]
        public void RemoverArtigo(ArtigoViewModel artigoViewModel)
        {
            var artigo = InstanciarArtigo(artigoViewModel);
            _service.RemoverArtigo(artigo);
        }

        [Route("PesquisarArtigo")]
        [HttpGet]
        public List<ArtigoViewModel> PesquisarArtigo([FromUri] string filter)
        {
            List<ArtigoViewModel> artigosVm = new List<ArtigoViewModel>();
            foreach (var artigo in _service.PesquisarArtigo(filter))
            {
                artigosVm.Add(new ArtigoViewModel(artigo));
            }

            return artigosVm;
        }

        private Artigo InstanciarArtigo(ArtigoViewModel cadArtigo)
        {
            var artigo = new Artigo();
            artigo.Id = cadArtigo.Id;
            artigo.DataPublicacao = DateTime.Now;
            //artigo.CategoriaId = cadArtigo.CategoriaId;
            artigo.Fotos = cadArtigo.Fotos;
            //artigo.PeixeId = cadArtigo.PeixeId;
            artigo.Status = StatusArtigo.Criado;
            artigo.Texto = cadArtigo.Texto;
            //artigo.UsuarioId = cadArtigo.UsuarioId;
            artigo.Categoria = cadArtigo.Categoria;
            artigo.Usuario = cadArtigo.Usuario;
            artigo.Peixe = cadArtigo.Peixe;
            
            return artigo;
        }
    }
}