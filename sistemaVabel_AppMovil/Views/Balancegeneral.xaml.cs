using System.Collections.ObjectModel;
using Balance_General.models;
using Microsoft.Maui.Controls;
using sistemaVabel_AppMovil.ViewModels;
using System;

namespace sistemaVabel_AppMovil.Views
{
    public partial class BalanceGeneralPage : ContentPage
    {
        public BalanceGeneralPage()
        {
            InitializeComponent();
            BindingContext = new BalanceView();
        }

<<<<<<< Updated upstream
        private async void back_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Si la navegación usa Shell (recomendado en MAUI), esto regresa una ruta arriba
                await Shell.Current.GoToAsync("..");

                // En caso de que la página se haya mostrado con Navigation.PushAsync, como respaldo:
                // if (Navigation.ModalStack.Count > 0)
                //     await Navigation.PopModalAsync();
                // else if (Navigation.NavigationStack.Count > 1)
                //     await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo regresar: {ex.Message}", "OK");
=======
        // Evento que se ejecuta al presionar el botón de regresar (◀)
        private async void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Intenta regresar de forma normal (si abriste con PushAsync)
                await Navigation.PopAsync();
            }
            catch
            {
                // Si la pantalla se abrió como Modal (PushModalAsync), 
                // entra aquí y la cierra correctamente para volver al MainPage.
                await Navigation.PopModalAsync();
>>>>>>> Stashed changes
            }
        }
    }
}