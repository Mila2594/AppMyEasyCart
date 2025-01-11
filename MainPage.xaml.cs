namespace AppEasyCart
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnIniciarSesionClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Funcionalidad en desarrollo", "Disculpe las molestias", "Ok");
        }

        private async void OnCrearCuentaTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Funcionalidad en desarrollo", "Disculpe las molestias", "Ok");
        }
    }

}
