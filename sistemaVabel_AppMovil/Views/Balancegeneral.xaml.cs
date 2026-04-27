using sistemaVabel_AppMovil.Data;
using sistemaVabel_AppMovil.Models;
using sistemaVabel_AppMovil.Vista;

namespace Balance_General
{
    public partial class MainPage : ContentPage
    {
        public BalancePage()
        {
            InitializeComponent();
            BindingContext = new BalanceView();
        }
    }
}
