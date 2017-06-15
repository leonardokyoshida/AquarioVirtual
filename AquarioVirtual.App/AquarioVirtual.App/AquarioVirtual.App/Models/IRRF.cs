using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.App.Models
{
    public class IRRF
    {
        public Guid Id { get; set; }
        public IList<MonthlyTableIRRF> MonthlyTableIRRF { get; set; }
    }
}
