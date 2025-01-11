using AppEasyCart.Models;
using AppEasyCart.Pages;
using AppEasyCart.ViewModels;

namespace AppEasyCart.Pages;

public partial class ProductsPage : ContentPage
{
    public ProductsPage()
    {
        InitializeComponent();
        BindingContext = new ProductListViewModel();

    }

   
    public async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
        var selectedProduct = e.CurrentSelection.FirstOrDefault() as Product;

        if (selectedProduct != null)
        {
            // Navegar a la p�gina de detalles con el ProductId como par�metro
            await Shell.Current.GoToAsync($"DetailProductPage?productId={selectedProduct.Id}");

            // Desmarcar el elemento despu�s de la navegaci�n
            (sender as CollectionView).SelectedItem = null;
        }
    }


}