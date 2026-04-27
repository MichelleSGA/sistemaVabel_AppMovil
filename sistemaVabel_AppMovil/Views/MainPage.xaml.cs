using sistemaVabel_AppMovil.Vista;

namespace sistemaVabel_AppMovil
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        // Este es el método que se ejecutará al presionar el botón rojo
        private async void OnAgregarGastoClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ModeloGastos());
        }
    }
}
