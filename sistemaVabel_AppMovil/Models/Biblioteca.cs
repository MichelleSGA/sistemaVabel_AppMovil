using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;


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

    public class Producto : INotifyPropertyChanged
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

        // --- CAMBIO AQUÍ: StockActual con notificación ------------------
        private int _stockActual;
        public int StockActual
        {
            get => _stockActual;
            set
            {
                if (_stockActual != value)
                {
                    _stockActual = value;
                    OnPropertyChanged(nameof(StockActual));
                    OnPropertyChanged(nameof(RequiereResurtido));
                }
            }
        }
//----------------------- 
        public int StockMinimo { get; set; }

        // Método auxiliar para la GUI (Alerta de escasez)
        [Ignore] // No se guarda en la base de datos, solo para la lógica de la GUI
        public bool RequiereResurtido => StockActual <= StockMinimo;
        // Propiedades para la venta y la burbuja amarilla
        private int _cantidadEnCarrito;
        public int CantidadEnCarrito
        {
            get => _cantidadEnCarrito;
            set
            {
                _cantidadEnCarrito = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TieneItems));
            }
        }

        public bool TieneItems => CantidadEnCarrito > 0;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
        // Lista simulada de productos (Esto después lo traerás de una base de datos)
        private List<Producto> _productosData = new List<Producto>
{
    new Producto {
        Nombre = "Leche Entera 1L",
        PrecioVenta = 25.50m,
        StockActual = 50,
        StockMinimo = 5,
        Descripcion = "leche"  
    },
    new Producto {
        Nombre = "Pan Blanco",
        PrecioVenta = 35.00m,
        StockActual = 20,
        StockMinimo = 3,
        Descripcion = "pan" 
    },
    new Producto {
        Nombre = "Huevo 12 pz",
        PrecioVenta = 45.00m,
        StockActual = 15,
        StockMinimo = 5,
        Descripcion = "huevos" 
    },
    new Producto {
        Nombre = "Arroz 1kg",
        PrecioVenta = 28.00m,
        StockActual = 40,
        StockMinimo = 10,
        Descripcion = "arroz" 
    },
    new Producto {
        Nombre = "Aceite de Oliva 500ml",
        PrecioVenta = 85.00m,
        StockActual = 15,
        StockMinimo = 2,
        Descripcion = "aceite"  
    },
    // NUEVO PRODUCTO 2: Refresco
    new Producto {
        Nombre = "Refresco Cola 2L",
        PrecioVenta = 32.50m,
        StockActual = 60,
        StockMinimo = 10,
        Descripcion = "refresco"
    }
};
        public async Task<List<Producto>> GetProductosAsync()
        {
            // Simulamos un retraso de red de 100ms
            await Task.Delay(100);
            return _productosData;
        }

        public event Action<string>? StockMinimoAlerta;

        // Métodos que los botones de la GUI mandarían a llamar
        public void RegistrarNuevoProducto(Producto nuevoProducto)
        {
            // Lógica para guardar en base de datos.
        }

        public void RegistrarMovimiento(MovimientoInventario movimiento, Producto producto)
        {
            if (movimiento.TipoMovimiento == TipoMovimientoInventario.EntradaCompra)
                producto.StockActual += movimiento.Cantidad;
            else if (movimiento.TipoMovimiento == TipoMovimientoInventario.SalidaVenta)
                producto.StockActual -= movimiento.Cantidad;
            else if (movimiento.TipoMovimiento == TipoMovimientoInventario.SalidaMerma)
                producto.StockActual -= movimiento.Cantidad;
            else if (movimiento.TipoMovimiento == TipoMovimientoInventario.Devolucion)
                producto.StockActual += movimiento.Cantidad;
            if (producto.RequiereResurtido)
            {
                NotificarCambioEnGUI_AlertaStockMinimo(producto.Nombre);
            }
        }
        private void NotificarCambioEnGUI_AlertaStockMinimo(string nombreProducto)
        {
            // Evento para mostrar un DisplayAlert en la Vista MAUI
            StockMinimoAlerta?.Invoke(nombreProducto);
        }
    }
}