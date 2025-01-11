using AppEasyCart.Models;
using AppEasyCart.ViewModels;



namespace AppEasyCart.Pages
{
    [QueryProperty(nameof(ProductId), "productId")]
    public partial class DetailProductPage : ContentPage
    {
        public int ProductId { get; set; }

       

        public DetailProductPage()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Usar la propiedad ProductId para obtener el producto
            var selectedProduct = await Task.Run(() => GetProductById(ProductId));

            if (selectedProduct != null)
            {
                // Crear la instancia de DetalleProductoViewModel y pasar las dependencias
                var detalleProductoViewModel = new DetalleProductoViewModel(ProductId);

                // Asignar el BindingContext
                BindingContext = detalleProductoViewModel;

                // Actualizar el título de la página
                Title = selectedProduct.Nombre;
            }

        }

        //metodo para obtener el producto por su id
        private Product GetProductById(int productId)
        {
            //consultar lista de productos
            return AppData.Instance.ListProductsBD.FirstOrDefault(p => p.Id == productId);
        }

        // Método para manejar el evento de agregar al carrito
        private async void OnAddToCartClicked(object sender, EventArgs e)
        {
            // Obtener el producto actual desde el BindingContext del ViewModel
            var viewModel = (DetalleProductoViewModel)BindingContext;
            var product = viewModel.Productovisualizado;

            // Agregar el producto al carrito usando CartService
            CartService.Instance.AddToCart(product);

            // Depuración para asegurarse de que el producto se agrega
            Console.WriteLine($"Producto {product.Nombre} agregado al carrito");

            // Mostrar un alert confirmando la adición al carrito
            bool result = await DisplayAlert("Producto agregado", "Producto agregado al carrito", "Seguir comprando", "Ir al carrito");

            if (!result)
            {
                // Navegar a la vista carrito
                await Shell.Current.GoToAsync("//CartPage",true);
                
            }



        }

        // Método para manejar el evento de agregar/eliminar de la lista de deseos
        private void OnAddToWishClicked(object sender, EventArgs e)
        {
            // Obtener el ViewModel actual
            var viewModel = (DetalleProductoViewModel)BindingContext;
            // Alternar el estado de la lista de deseos
            viewModel.ToggleWishList();
        }
    }
}
