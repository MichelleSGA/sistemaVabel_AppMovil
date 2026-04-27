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

        private async void back_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo regresar: {ex.Message}", "OK");
            }
        } 

        // Evento que se ejecuta al presionar el botón de regresar (◀)
        private async void BtnRegresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PopAsync();
            }
            catch
            {
                await Navigation.PopModalAsync();
            }
        }
    } // Cierra la clase
} // Cierra el namespace