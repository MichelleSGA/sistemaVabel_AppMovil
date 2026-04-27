using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using sistemaVabel_AppMovil.Views; // Importante para poder abrir la página de BalanceGeneralPage

namespace sistemaVabel_AppMovil.ViewModels
{
    public class MainViewModel
    {
        public string GananciasHoy { get; set; }

        // Comandos de navegación del Lobby
        public ICommand NavegarLibretaCommand { get; }
        public ICommand NavegarInventarioCommand { get; }
        public ICommand NavegarBalanceCommand { get; } // Nuevo comando para el Balance

        public MainViewModel()
        {
            GananciasHoy = "$100.00"; // En el futuro, esto se calculará desde SQLite

            // Navegamos a la Libreta de Ventas usando el sistema de rutas de Shell
            NavegarLibretaCommand = new Command(async () =>
                await Shell.Current.GoToAsync("LibretaVentasPage"));

            // Comando para el inventario (por implementar)
            NavegarInventarioCommand = new Command(() => { /* Por implementar */ });

            // Comando que abre el Balance General como ventana modal sin borrar la principal
            NavegarBalanceCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new BalanceGeneralPage());
            });
        }
    }
}