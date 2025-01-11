using AppEasyCart.Models;
using System.Windows.Input;

namespace AppEasyCart.Pages;

public partial class WishListPage : ContentPage
{
    
    public WishListPage()
	{
		InitializeComponent();
        BindingContext = WishlistService.Instance; // Esto ahora se actualizará con ItemWishList
        Console.WriteLine("Elementos en la lista de deseos: " + WishlistService.Instance.WishList.Count);
        
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        var imageButton = (ImageButton)sender;
        var product = (Product)imageButton.CommandParameter;

        // Aquí se agrega el producto al carrito
        CartService.Instance.AddToCart(product);

        // Mostrar el mensaje de confirmación
        await DisplayToast("Producto agregado al carrito");
        Console.WriteLine($"Producto agregado: {product.Nombre}");
    }

    private async Task DisplayToast(string message)
    {
        // Mostrar un mensaje en la pantalla por un tiempo corto
        await DisplayAlert(string.Empty, message, "Aceptar");
        // Si quieres hacer que el mensaje dure más, puedes agregar un delay aquí
        await Task.Delay(2000); // El mensaje desaparecerá después de 2 segundos
    }
}