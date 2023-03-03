using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperClean.Core.Entities
{
    public class Credito
    {
        public int Valor { get; set; }
        public float Interes { get; set;}
        public int Cuotas { get; set; }
    }
}
