using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace sistemaVabel_AppMovil.ViewModels
{
    public class MainViewModel
    {
        public string GananciasHoy { get; set; }

        // Comandos de navegación del Lobby
        public ICommand NavegarLibretaCommand { get; }
        public ICommand NavegarInventarioCommand { get; }

        public MainViewModel()
        {
            GananciasHoy = "$100.00"; // En el futuro, esto se calculará desde SQLite

            // Navegamos a la Libreta de Ventas usando el sistema de rutas de Shell
            NavegarLibretaCommand = new Command(async () =>
                await Shell.Current.GoToAsync("LibretaVentasPage"));

            NavegarInventarioCommand = new Command(() => { /* Por implementar */ });
        }
    }
}
