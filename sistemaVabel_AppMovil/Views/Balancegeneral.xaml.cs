using System.Collections.ObjectModel;
using Balance_General.models;
using Microsoft.Maui.Controls;
using sistemaVabel_AppMovil.ViewModels;

namespace sistemaVabel_AppMovil.Views
{
    public partial class BalanceGeneralPage : ContentPage
    {
        public BalanceGeneralPage()
        {
            InitializeComponent();
            BindingContext = new BalanceView();
        }
    }
}