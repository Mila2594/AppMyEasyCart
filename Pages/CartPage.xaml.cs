using AppEasyCart.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppEasyCart.Pages;

public partial class CartPage : ContentPage, INotifyPropertyChanged
{
    private ObservableCollection<ItemCart> _cartItems;
    public ObservableCollection<ItemCart> CartItems
    {
        get => _cartItems;
        set
        {
            if (_cartItems != value)
            {
                // Quitar suscripción a eventos anteriores
                if (_cartItems != null)
                {
                    foreach (var item in _cartItems)
                        item.PropertyChanged -= OnCartItemPropertyChanged;
                }

                _cartItems = value;
                OnPropertyChanged();

                // Suscribirse a eventos de cada nuevo item en CartItems
                foreach (var item in _cartItems)
                    item.PropertyChanged += OnCartItemPropertyChanged;

                RecalculateTotal();
            }
        }
    }

    private decimal _total;
    public decimal Total
    {
        get => _total;
        private set
        {
            if (_total != value)
            {
                _total = value;
                OnPropertyChanged();
            }
        }
    }

    private string _pagarButtonText;
    public string PagarButtonText
    {
        get => _pagarButtonText;
        set
        {
            if (_pagarButtonText != value)
            {
                _pagarButtonText = value;
                OnPropertyChanged();
            }
        }
    }


    public ICommand AgregarProductoCommand { get; }
    public ICommand EliminarProductoCommand { get; }

    public CartPage()
    {
        InitializeComponent();
        BindingContext = this;

        AgregarProductoCommand = new Command<Product>(AddToCart);
        EliminarProductoCommand = new Command<Product>(RemoveFromCart);
        

        CartItems = CartService.Instance.CartItems;

        // Suscribirse al evento PropertyChanged de CartService
        CartService.Instance.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(CartService.CartItems))
            {
                CartItems = CartService.Instance.CartItems;
            }
        };

        RecalculateTotal();
        UpdatePagarButtonText();
    }

    private void RecalculateTotal()
    {
        Total = CartItems
            .Where(item => item.IsSelected)
            .Sum(item => item.Product.Precio * item.Cantidad);
        UpdatePagarButtonText();
    }

    private void OnCartItemPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ItemCart.IsSelected) || e.PropertyName == nameof(ItemCart.Cantidad))
        {
            RecalculateTotal();
        }
    }

    private void UpdatePagarButtonText()
    {
        int selectedCount = CartItems.Count(item => item.IsSelected);
        PagarButtonText = $"Pagar ({selectedCount})";
    }

    private async void OnPagar(object sender, EventArgs e)
    {
        await DisplayAlert("Funcionalidad en Desarrollo", "Disculpe las molestias", "OK");
    }

    private void AddToCart(Product product)
    {
        CartService.Instance.AddToCart(product);
        RecalculateTotal();
    }

    private void RemoveFromCart(Product product)
    {
        CartService.Instance.RemoveFromCart(product);
        RecalculateTotal();
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RecalculateTotal();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
