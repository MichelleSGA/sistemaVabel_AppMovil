using Microsoft.Maui.Controls; // Asegura que esta directiva esté presente
using sistemaVabel_AppMovil.Views;
using System.Threading.Tasks;

namespace sistemaVabel_AppMovil.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent(); // Este método es generado automáticamente por el archivo XAML asociado
    }

    // Este es el método que se ejecutará al presionar el botón rojo
    private async void OnAgregarGastoClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ModeloGastos());
    }

    private async void OnMiInventarioClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InventarioPage());
    }

    private async void OnAgregarVentaClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NuevaVentaPage());
    }
}
