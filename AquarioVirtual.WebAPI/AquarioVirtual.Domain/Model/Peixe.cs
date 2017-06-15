using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.Domain.Model
{
    public class Peixe : ModelBase
    {
        public double PH { get; set; }
        public string Familia { get; set; }
        public string Tamanho { get; set; }
        public double Temperatura { get; set; }
        public string TamanhoAquario { get; set; }
        public string Habitat { get; set; }
        public string Nome { get; set; }
        public string NomeCientifico { get; set; }
        public IObservable<Artigo> Artigos { get; set; }


    }
}
