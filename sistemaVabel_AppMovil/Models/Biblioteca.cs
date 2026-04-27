using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace sistemaVabel_AppMovil.Models
{
    // MÓDULO DE GESTIÓN DE INVENTARIO
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement]
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string InformacionContacto { get; set; }
    }

    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int ProductoId { get; set; }
        public string CodigoBarra { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }

        // Relación con Proveedor
        public int ProveedorId { get; set; }
        [Ignore] // Ignorar en la base de datos, solo para la GUI
        public Proveedor ProveedorAsociado { get; set; }

        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }

        public int StockActual { get; set; }
        public int StockMinimo { get; set; }

        // Método auxiliar para la GUI (Alerta de escasez)
        [Ignore] // No se guarda en la base de datos, solo para la lógica de la GUI
        public bool RequiereResurtido => StockActual <= StockMinimo;
    }

    public enum TipoMovimientoInventario
    {
        EntradaCompra,
        SalidaVenta,
        SalidaMerma,
        Devolucion
    }

    public class MovimientoInventario
    {
        [PrimaryKey, AutoIncrement]
        public int MovimientoId { get; set; }
        public int ProductoId { get; set; }
        public TipoMovimientoInventario TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaMovimiento { get; set; } = DateTime.Now;
        public string Notas { get; set; }
    }

    // MÓDULO DE CONTABILIDAD

    public class CuentaContable
    {
        [PrimaryKey, AutoIncrement]
        public int CuentaId { get; set; }
        public string NombreCuenta { get; set; } // "Ventas", "Renta", "Pago de Luz"
        public string TipoCuenta { get; set; } // Ingreso, Egreso, Activo, Pasivo
    }

    public class TransaccionFinanciera
    {
        [PrimaryKey, AutoIncrement]
        public int TransaccionId { get; set; }
        public DateTime FechaTransaccion { get; set; } = DateTime.Now;
        public decimal Monto { get; set; }

        // Relación con el catálogo de cuentas
        public int CuentaId { get; set; }
        [Ignore] // Ignorar en la base de datos, solo para la GUI
        public CuentaContable CuentaAsociada { get; set; }

        // Indica si es dinero que entra o sale
        public bool EsIngreso { get; set; }
        public string Concepto { get; set; }

        public int? MovimientoInventarioId { get; set; }
    }

    public class CuentaPorCobrarPagar
    {
        [PrimaryKey, AutoIncrement]
        public int DeudaId { get; set; }
        public string NombreClienteProveedor { get; set; }
        public decimal MontoTotalDeuda { get; set; }
        public decimal SaldoPendiente { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool EsCuentaPorCobrar { get; set; } // True = Nos deben (Cliente), False = Debemos (Proveedor)
        public bool EstaSaldada => SaldoPendiente <= 0;
    }

    // SERVICIOS SIMULADOS (Interacción con GUI / ViewModels)

    public class InventarioService
    {
        // Métodos que los botones de la GUI mandarían a llamar
        public void RegistrarNuevoProducto(Producto nuevoProducto)
        {
            // Lógica para guardar en base de datos.
        }

        public void RegistrarMovimiento(MovimientoInventario movimiento, Producto producto)
        {
            // 1. Registrar el movimiento
            // 2. Actualizar el stock automáticamente
            if (movimiento.TipoMovimiento == TipoMovimientoInventario.EntradaCompra)
                producto.StockActual += movimiento.Cantidad;
            else
                producto.StockActual -= movimiento.Cantidad;

            if (producto.RequiereResurtido)
            {
                NotificarCambioEnGUI_AlertaStockMinimo(producto.Nombre);
            }
        }
        private void NotificarCambioEnGUI_AlertaStockMinimo(string nombreProducto)
        {
            // Evento para mostrar un DisplayAlert en la Vista MAUI
        }
    }
}
