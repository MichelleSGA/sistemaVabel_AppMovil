using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace sistemaVabel_AppMovil.ViewModels
{
    public class LoginViewModel
    {
        public string CorreoUsuario { get; set; }

        public ICommand ContinuarCommand { get; }

        public LoginViewModel()
        {
            ContinuarCommand = new Command(async () => await IniciarSesionAsync());
        }

        private async Task IniciarSesionAsync()
        {
            if (string.IsNullOrWhiteSpace(CorreoUsuario))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Ingresa un correo", "OK");
                return;
            }

            // Cambiamos la raíz de la aplicación al AppShell (Lobby)
            // Esto evita que el usuario pueda darle "Atrás" y regresar al Login
            Application.Current.MainPage = new AppShell();
        }
    }
}
