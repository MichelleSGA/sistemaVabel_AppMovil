namespace sistemaVabel_AppMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // La app arranca en el Login (fuera del Shell)
            MainPage = new Views.LoginPage();
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}