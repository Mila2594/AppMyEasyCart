using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEasyCart.Models
{
    public class CartService : INotifyPropertyChanged
    {
        // Lista mutable del carrito
        private ObservableCollection<ItemCart> _cartItems;

        // Instancia única del singleton
        private static CartService _instance;

        // Propiedad para acceder a la lista del carrito
        public ObservableCollection<ItemCart> CartItems => _cartItems;

        // Constructor privado para evitar instanciación externa
        private CartService()
        {
            _cartItems = new ObservableCollection<ItemCart>();
        }

        // Método para obtener la instancia única del singleton
        public static CartService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CartService();
                }
                return _instance;
            }
        }

        // Método para agregar un producto al carrito
        public void AddToCart(Product product)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Cantidad++;  // Incrementar la cantidad si ya está en el carrito
            }
            else
            {
                _cartItems.Add(new ItemCart { Product = product, Cantidad = 1 });
            }

            // Notificar cambios
            OnPropertyChanged(nameof(CartItems));
        }

        // Método para eliminar o reducir cantidad de un producto en el carrito
        public void RemoveFromCart(Product product)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                if (existingItem.Cantidad > 1)
                {
                    existingItem.Cantidad--;  // Reducir la cantidad si es mayor a 1
                }
                else
                {
                    _cartItems.Remove(existingItem);  // Eliminar el producto si la cantidad es 1
                }

                // Notificar cambios
                OnPropertyChanged(nameof(CartItems));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
