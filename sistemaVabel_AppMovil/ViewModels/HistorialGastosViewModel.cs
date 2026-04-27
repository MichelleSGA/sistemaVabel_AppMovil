using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using sistemaVabel_AppMovil.Models;
using sistemaVabel_AppMovil.Data;

namespace sistemaVabel_AppMovil.ViewModels
{
    public class HistorialGastosViewModel
    {
        // ObservableCollection avisa a la pantalla automáticamente cuando hay nuevos elementos en la lista
        public ObservableCollection<GastoModelo> ListaGastos { get; set; }

        public ICommand VolverCommand { get; }

        private ServicioGasto _servicioGasto;

        public HistorialGastosViewModel()
        {
            // Instanciamos tu servicio de base de datos
            _servicioGasto = new ServicioGasto();
            ListaGastos = new ObservableCollection<GastoModelo>();

            // Comando para nuestra flecha de retroceso
            VolverCommand = new Command(async () => await Shell.Current.GoToAsync(".."));

            // Cargamos los datos al iniciar
            CargarGastos();
        }

        private void CargarGastos()
        {
            // Utilizamos el método listarGastos() de tu archivo ServicioGasto.cs
            var gastosObtenidos = _servicioGasto.listarGastos();

            ListaGastos.Clear(); // Limpiamos por si acaso

            // Pasamos los datos de la lista tradicional a nuestra lista "Observable"
            foreach (var gasto in gastosObtenidos)
            {
                ListaGastos.Add(gasto);
            }
        }
    }
}
