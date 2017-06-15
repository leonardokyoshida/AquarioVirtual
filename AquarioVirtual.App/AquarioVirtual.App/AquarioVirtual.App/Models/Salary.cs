using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.App.Models
{
    public class Salary
    {
        public double GrossSalary { get; set; }
        public double NetSalary  { get; set; }
        public double Tax { get; set; }
        public MonthlyTableIRRF MonthlyTableIRRF { get; set; }
    }
}
