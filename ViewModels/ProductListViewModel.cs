using AppEasyCart.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AppEasyCart.ViewModels
{
    public class ProductListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Productos { get; set; }

        public ICommand SelectProductCommand { get; }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    // Aquí puedes manejar el cambio, por ejemplo, mostrar más detalles
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }

        public ProductListViewModel()
        {
            SelectProductCommand = new Command<Product>((selectedProduct) =>
            {
                // Aquí puedes manejar la acción cuando un producto es seleccionado
                SelectedProduct = selectedProduct;
                // Muestra un alert o realiza alguna otra acción
            });

            Productos = new ObservableCollection<Product>();

            //cartar lista de productos desde la clase AppData
            CargarLista();

        }

        //metodo para cargar la lista de productos
        public void CargarLista()
        {
            var productos = AppData.Instance.ListProductsBD;

            //limpiar cualquier dato anterior (en caso de que se recargue)
            Productos.Clear();

            //agregar los productos a la lista
            foreach (var item in productos)
            {
                Productos.Add(item);
            }
        }

        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
