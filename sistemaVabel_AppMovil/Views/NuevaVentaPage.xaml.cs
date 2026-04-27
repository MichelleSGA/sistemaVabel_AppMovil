using Microsoft.Maui.Controls; // o Xamarin.Forms si es un proyecto Xamarin
using sistemaVabel_AppMovil.Models;
using sistemaVabel_AppMovil.ViewModels;
using System.Collections.ObjectModel;

namespace sistemaVabel_AppMovil.Views
{ 
public partial class NuevaVentaPage : ContentPage
{
    decimal total = 0;
    int items = 0;
    ObservableCollection<Producto> _productosCompletos = new ObservableCollection<Producto>();

    public NuevaVentaPage()
    {
        InitializeComponent();
        CargarDatos();
    }

    private async void CargarDatos()
    {
        var servicio = new InventarioService();
        var lista = await servicio.GetProductosAsync();
        _productosCompletos = new ObservableCollection<Producto>(lista);
        ListaProductosView.ItemsSource = _productosCompletos;
    }

    private void OnAgregarProductoClicked(object sender, EventArgs e)
    {
        var border = (Border)sender;
        var producto = (Producto)border.BindingContext;
        if (producto != null)
        {
            producto.CantidadEnCarrito++;
            total += producto.PrecioVenta;
            items++;
            ActualizarLabelsFooter();
            border.ScaleTo(1.2, 100).ContinueWith(t => border.ScaleTo(1.0, 100));
        }
    }

    private void OnQuitarProductoClicked(object sender, EventArgs e)
    {
        var border = (Border)sender;
        var producto = (Producto)border.BindingContext;
        if (producto != null && producto.CantidadEnCarrito > 0)
        {
            producto.CantidadEnCarrito--;
            total -= producto.PrecioVenta;
            items--;
            ActualizarLabelsFooter();
            border.ScaleTo(1.2, 100).ContinueWith(t => border.ScaleTo(1.0, 100));
        }
    }

    private void ActualizarLabelsFooter()
    {
        lblTotal.Text = $"Total: {total:C}";
        lblConteo.Text = $"{items} productos seleccionados";
        btnContinuar.IsEnabled = items > 0;
    }

    private async void OnConfirmarClicked(object sender, EventArgs e)
    {
        if (items == 0) return;
        var seleccionados = _productosCompletos.Where(p => p.CantidadEnCarrito > 0).ToList();
        string detalle = "Resumen:\n\n";
        foreach (var p in seleccionados)
            detalle += $"{p.CantidadEnCarrito}x {p.Nombre} - {p.CantidadEnCarrito * p.PrecioVenta:C}\n";

        bool confirmar = await DisplayAlert("¿Finalizar?", detalle + $"\nTotal: {total:C}", "Cobrar", "Cancelar");
        if (confirmar)
        {
            await DisplayAlert("Éxito", "Venta registrada", "OK");
            ResetearPagina();
        }
    }

    private void ResetearPagina()
    {
        foreach (var p in _productosCompletos) p.CantidadEnCarrito = 0;
        total = 0; items = 0;
        ActualizarLabelsFooter();
    }

    private void OnBusquedaChanged(object sender, TextChangedEventArgs e)
    {
        string busqueda = e.NewTextValue?.ToLower() ?? "";
        ListaProductosView.ItemsSource = string.IsNullOrWhiteSpace(busqueda)
            ? _productosCompletos
            : _productosCompletos.Where(p => p.Nombre.ToLower().Contains(busqueda)).ToList();
    }

    private void OnProductoTapped(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Producto prod)
        {
            prod.CantidadEnCarrito++;
            total += prod.PrecioVenta;
            items++;
            ActualizarLabelsFooter();
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
}