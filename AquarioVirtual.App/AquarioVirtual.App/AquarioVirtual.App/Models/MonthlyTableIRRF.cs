using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.App.Models
{
    public class MonthlyTableIRRF
    {
        public Guid Id { get; set; }
        public double CalculationBasisInitial { get; set; }
        public double CalculationBasisEnd { get; set; }
        public double Aliquot { get;  set; }
        public double PortionToDeducted { get;  set; }
    }
}
