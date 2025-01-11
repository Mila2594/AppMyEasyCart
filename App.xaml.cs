using AppEasyCart.Pages;

namespace AppEasyCart
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           
            MainPage = new AppShell();


        }
    }
}
