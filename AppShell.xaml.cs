using AppEasyCart.Pages;

namespace AppEasyCart
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("DetailProductPage", typeof(DetailProductPage));
        }

        private async void OnCartButtonClicked(object sender, EventArgs e)
        {
            // Navegar a la página CartPage
            await Shell.Current.GoToAsync("//CartPage");
        }

    }
}
