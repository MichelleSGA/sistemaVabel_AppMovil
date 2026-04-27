using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemaVabel_AppMovil.Models
{
    [Table("gastos_operativos")]
    public class GastoModelo
    {
        [PrimaryKey, AutoIncrement]
        public int id_gastos { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public double monto { get; set; }
        public double tasa_iva { get; set; }
        public string observaciones { get; set; }
        public string forma_pago { get; set; }

        public GastoModelo() { }

        public GastoModelo(DateTime fecha, string descripcion, double monto, double tasa_iva, string observaciones, string forma_pago)
        {
            this.fecha = fecha;
            this.descripcion = descripcion ?? string.Empty;
            this.monto = monto;
            this.tasa_iva = tasa_iva;
            this.observaciones = observaciones ?? string.Empty;
            this.forma_pago = forma_pago ?? string.Empty;
        }
    }
}
