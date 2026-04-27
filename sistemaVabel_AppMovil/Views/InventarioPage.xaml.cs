using sistemaVabel_AppMovil.Data;
using sistemaVabel_AppMovil.Models;
using sistemaVabel_AppMovil.Views;
using System.Windows.Input;

namespace sistemaVabel_AppMovil.Views
{
    public partial class InventarioPage : ContentPage
    {
        public InventarioPage()
        {
            InitializeComponent();
        }

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
            }
        }
    }
}