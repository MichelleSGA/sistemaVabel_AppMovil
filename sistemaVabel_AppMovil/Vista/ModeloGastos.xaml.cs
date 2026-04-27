using sistemaVabel_AppMovil.Control;
using sistemaVabel_AppMovil.Modelo;
using sistemaVabel_AppMovil.Vista;

namespace sistemaVabel_AppMovil.Vista;

public partial class ModeloGastos : ContentPage
{
    ServicioGasto ControlGasto;
    ServicioDB servicioDBC;

    private string _categoriaSeleccionada = string.Empty;
    private string _metodoPagoSeleccionado = string.Empty;
    public ModeloGastos()
	{
        InitializeComponent();
        ControlGasto = new ServicioGasto();
        servicioDBC = new ServicioDB();
        servicioDBC.crear();
    }
    // Selección de categoría
    void OnCategoryTapped(object sender, TappedEventArgs e)
    {
        borderAlquiler.StrokeThickness = 0;
        borderAlquiler.Stroke = Colors.Transparent;
        borderLuz.StrokeThickness = 0;
        borderLuz.Stroke = Colors.Transparent;
        borderSueldos.StrokeThickness = 0;
        borderSueldos.Stroke = Colors.Transparent;

        // Pintar borde al seleccionar
        if (sender is Border bordeTocado)
        {
            bordeTocado.StrokeThickness = 3;
            bordeTocado.Stroke = Color.FromArgb("#67BAD3");
        }

        // Guardamos el valor en base de datos
        if (e.Parameter != null)
        {
            _categoriaSeleccionada = e.Parameter.ToString();
        }
    }

    // Selección de metodo de pago
    void OnPaymentMethodTapped(object sender, TappedEventArgs e)
    {
        borderEfectivo.StrokeThickness = 0;
        borderEfectivo.Stroke = Colors.Transparent;
        borderTarjeta.StrokeThickness = 0;
        borderTarjeta.Stroke = Colors.Transparent;

        if (sender is Border bordeTocado)
        {
            bordeTocado.StrokeThickness = 3;
            bordeTocado.Stroke = Color.FromArgb("#67BAD3");
        }

        if (e.Parameter != null)
        {
            _metodoPagoSeleccionado = e.Parameter.ToString();
        }
    }

    // Botón guardar
    private async void OnRegisterClicked(object? sender, EventArgs e)
    {
        try
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !double.TryParse(txtMonto.Text, out double montoIngresado))
            {
                await DisplayAlert("Error", "Por favor ingresa un monto válido.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(_categoriaSeleccionada))
            {
                await DisplayAlert("Aviso", "Por favor selecciona el concepto del gasto.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(_metodoPagoSeleccionado))
            {
                await DisplayAlert("Aviso", "Por favor selecciona un método de pago.", "OK");
                return;
            }

            // Observaciones en base al RadioButton
            string notas = rbCaja.IsChecked ? "El efectivo salió de caja" : "No salió de caja";

            DateTime fechaGasto = datePicker.Date;

            // Crear objeto Modelo
            GastoModelo nuevoGasto = new GastoModelo(
                fecha: fechaGasto,
                descripcion: _categoriaSeleccionada,
                monto: montoIngresado,
                tasa_iva: 0, // Asumiendo que por ahora es 0, o puedes agregar un Entry extra después
                observaciones: notas,
                forma_pago: _metodoPagoSeleccionado
            );

            // Guardar en SQLite
            ControlGasto.insertarGasto(nuevoGasto);

            // Confirmación y limpieza de pantalla
            await DisplayAlert("Éxito", "El gasto se ha registrado correctamente.", "OK");
            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error de guardado", $"Ocurrió un problema: {ex.Message}", "OK");
        }
    }
    private void LimpiarFormulario()
    {
        txtMonto.Text = string.Empty;
        datePicker.Date = DateTime.Now;
        _categoriaSeleccionada = string.Empty;
        _metodoPagoSeleccionado = string.Empty;
        rbCaja.IsChecked = false;

        // Limpiar los colores de los bordes
        borderAlquiler.StrokeThickness = 0;
        borderLuz.StrokeThickness = 0;
        borderSueldos.StrokeThickness = 0;

        borderEfectivo.StrokeThickness = 0;
        borderTarjeta.StrokeThickness = 0;
    }
}