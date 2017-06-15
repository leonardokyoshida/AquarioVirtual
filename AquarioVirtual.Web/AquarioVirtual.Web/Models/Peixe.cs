using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AquarioVirtual.Web.Models
{
    public class Peixe
    {
        public string Id { get; set; }
        [Display(Name = "PH: ")]
        public double PH { get; set; }
        [Display(Name = "Familia: ")]
        public string Familia { get; set; }
        [Display(Name = "Tamanho: ")]
        public string Tamanho { get; set; }
        [Display(Name = "Temperatura: ")]
        public double Temperatura { get; set; }
        [Display(Name = "Tamanho aquário recomendado: ")]
        public string TamanhoAquario { get; set; }
        [Display(Name = "Habitat: ")]
        public string Habitat { get; set; }
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }
        [Display(Name = "Nome científico: ")]
        public string NomeCientifico { get; set; }
        public IObservable<Artigo> Artigos { get; set; }
    }
}