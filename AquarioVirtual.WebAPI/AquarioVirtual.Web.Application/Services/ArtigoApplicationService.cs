using AquarioVirtual.Domain.Model;
using AquarioVirtual.Domain.Interfaces;
using AquarioVirtual.Domain.Services.ArtigosServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AquarioVirtual.Web.Application.Services
{
    public class ArtigoApplicationService : ApplicationService, IArtigoApplicationService
    {
        private readonly IArtigoRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IPeixeRepository _peixeRepository;
        public ArtigoApplicationService(IArtigoRepository repository, IUsuarioRepository usuarioRepository,
            ICategoriaRepository categoriaRepository, IPeixeRepository peixeRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _categoriaRepository = categoriaRepository;
            _peixeRepository = peixeRepository;
        }
        public Artigo CriarArtigo(Artigo artigo)
        {
            artigo.Categoria = _categoriaRepository.GetById(artigo.Categoria?.Id);
            artigo.Usuario = _usuarioRepository.GetById(artigo.Usuario?.Id);
            artigo.Peixe = _peixeRepository.Add(artigo.Peixe);
            _repository.Add(artigo);

            return artigo;
        }

        public List<Artigo> ObterUltimosArtigos()
        {
            return _repository.GetAll()?.Take(10).ToList();
        }

        public Artigo ObterArtigo(string id)
        {
            return _repository.GetById(id);
        }

        public void RemoverArtigo(Artigo artigo)
        {
            _repository.Remove(artigo);
        }

        public List<Artigo> PesquisarArtigo(string filter)
        {
            return _repository.GetFilter(filter)?.ToList();
        }
    }
}
