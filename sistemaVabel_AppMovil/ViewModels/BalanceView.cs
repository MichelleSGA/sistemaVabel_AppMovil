using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Balance_General.models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemaVabel_AppMovil.ViewModels
{
    public class BalanceView
    {
        // Totales del día
        public string IngresoTotal { get; set; } = "$4,520.00";
        public string Efectivo { get; set; } = "$3,000.00";
        public string Tarjeta { get; set; } = "$1,000.00";
        public string Transferencia { get; set; } = "$520.00";

        // Resumen operativo
        public string VentasTotales { get; set; } = "42";
        public string TicketPromedio { get; set; } = "$107.61";

        // Lista de las ventas recientes
        public ObservableCollection<Transaccion> UltimasVentas { get; set; }

        public BalanceView()
        {
            // Datos de prueba simulando el flujo de la tiendita
            UltimasVentas = new ObservableCollection<Transaccion>
            {
                new Transaccion { Hora = "14:30", Descripcion = "Ticket #045", Detalles = "Abarrotes y Lácteos (3 arts.)", Monto = 150.00m },
                new Transaccion { Hora = "14:15", Descripcion = "Ticket #044", Detalles = "Botanas y Refrescos (2 arts.)", Monto = 85.50m },
                new Transaccion { Hora = "13:50", Descripcion = "Ticket #043", Detalles = "Limpieza (1 art.)", Monto = 45.00m },
                new Transaccion { Hora = "13:10", Descripcion = "Ticket #042", Detalles = "Varios (5 arts.)", Monto = 320.00m }
            };
        }
    }
}
