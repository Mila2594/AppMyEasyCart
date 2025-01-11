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
            // Navegar a la página de detalles con el ProductId como parámetro
            await Shell.Current.GoToAsync($"DetailProductPage?productId={selectedProduct.Id}");

            // Desmarcar el elemento después de la navegación
            (sender as CollectionView).SelectedItem = null;
        }
    }


}