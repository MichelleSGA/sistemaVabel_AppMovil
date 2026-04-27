using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls; // Necesario para la clase Command nativa de MAUI

namespace sistemaVabel_AppMovil.ViewModels
{
    // Clase tradicional sin dependencias externas. 
    // Ideal para prototipar la GUI rápidamente.
    public class LibretaVentasViewModel
    {
        // Propiedades de texto simple para la vista
        public string GananciasTotales { get; set; }
        public string GastosTotales { get; set; }

        public ObservableCollection<ProductoVendido> ProductosTop { get; set; }

        // Comandos nativos (ICommand) para que los botones no tiren error en el XAML,
        // aunque de momento no hagan nada visualmente.
        public ICommand SeleccionarPeriodoCommand { get; }
        public ICommand NavegarGastosCommand { get; }
        public ICommand NavegarVentasCommand { get; }
        public ICommand BackCommand { get; }

        public LibretaVentasViewModel()
        {
            // 1. Cargamos los datos "Mock" (de prueba) para verlos en la GUI
            GananciasTotales = "$1,493,500.00";
            GastosTotales = "$650.00";

            ProductosTop = new ObservableCollection<ProductoVendido>
            {
                new ProductoVendido { Nombre = "Top-product 1", Icono = "🥇" },
                new ProductoVendido { Nombre = "Top-product 2", Icono = "🥈" },
                new ProductoVendido { Nombre = "Top-product 3", Icono = "🥉" }
            };

            // 2. Inicializamos los comandos vacíos para que la app no colapse al presionarlos
            SeleccionarPeriodoCommand = new Command(() => { /* Sin acción por ahora */ });
            NavegarGastosCommand = new Command(async () => await Shell.Current.GoToAsync("HistorialGastosPage"));
            NavegarVentasCommand = new Command(() => { /* Sin acción por ahora */ });
            BackCommand = new Command(async () => await RegresarAsync());
        }
        private async Task RegresarAsync()
        {
            // Lógica para regresar a la página anterior
            await Shell.Current.GoToAsync("..");
        }
    }
    // Clase auxiliar para la lista
    public class ProductoVendido
    {
        public string Nombre { get; set; }
        public string Icono { get; set; }
    }
}