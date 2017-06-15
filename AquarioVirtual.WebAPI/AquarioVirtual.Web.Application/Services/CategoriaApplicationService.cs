using AquarioVirtual.Domain.Services.CategoriaServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquarioVirtual.Domain.Model;
using AquarioVirtual.Domain.Interfaces;

namespace AquarioVirtual.Web.Application.Services
{
    public class CategoriaApplicationService : ApplicationService, ICriarCategoriaApplicationService, 
        IObterCategoriasApplicationService
    {
        public CategoriaApplicationService(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        private readonly ICategoriaRepository _repository;
        public Categoria CriarCategoria(Categoria categoria)
        {
            categoria = _repository.GetById(categoria.Id);
            categoria.Descricao += "2";
            categoria = _repository.Add(categoria);

            _repository.Remove(categoria);
            return categoria;
        }

        public List<Categoria> ObterCategorias()
        {
            return _repository.GetAll()?.ToList();
        }

    }
}
