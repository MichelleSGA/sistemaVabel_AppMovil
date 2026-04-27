using sistemaVabel_AppMovil.Views;

namespace sistemaVabel_AppMovil
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Registramos la ruta de la pantalla para poder navegar hacia ella desde cualquier botón.
            // Esto es ideal para pantallas secundarias que no van en el menú principal.
            // Registramos la ruta para que MainPage pueda viajar a LibretaVentasPage
            Routing.RegisterRoute("LibretaVentasPage", typeof(Views.LibretaVentasPage));
        }
    }
}
