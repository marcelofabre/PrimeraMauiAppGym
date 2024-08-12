using PrimeraMauiApp.Models;
using PrimeraMauiApp.Repositories;
using System.Collections.ObjectModel;

namespace PrimeraMauiApp.Pages;

public partial class ejerciciosPage : ContentPage
{
	Ejercicio libroSeleccionado;
	ejerciciosRepositorio librosRepositorio = new ejerciciosRepositorio();
    ObservableCollection<Ejercicio>? libros = new ObservableCollection<Ejercicio>();

	public ejerciciosPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        libros = await librosRepositorio.ObtenerejerciciosAsync();
        CollectionLibros.ItemsSource = libros;
    }
    private void btnVolver_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}