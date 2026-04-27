using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balance_General.models
{
    public class Transaccion
    {
        public string Hora {  get; set; }
        public string Descripcion { get; set; }
        
        public string Detalles { get; set; }

        public decimal Monto { get; set; }
        
        public string MontoFormateado => Monto.ToString("C");
    }
}
