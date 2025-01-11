using AppEasyCart.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace AppEasyCart.ViewModels
{
    public class DetalleProductoViewModel : INotifyPropertyChanged
    {
        private Product _productovisualizado;
        public Product Productovisualizado
        {
            get => _productovisualizado;
            set
            {
                _productovisualizado = value;
                OnPropertyChanged(nameof(Productovisualizado));
            }
        }
        public ObservableCollection<Opinion> Opiniones { get; set; } 

        // Propiedades de visibilidad para alternar las vistas
        private bool isDatosVisible = true;
        public bool IsDatosVisible
        {
            get => isDatosVisible;
            set
            {
                if (isDatosVisible != value)
                {
                    isDatosVisible = value;
                    OnPropertyChanged(nameof(IsDatosVisible));
                }
            }
        }
        private bool isOpinionesVisible = false;
        public bool IsOpinionesVisible
        {
            get => isOpinionesVisible;
            set
            {
                if (isOpinionesVisible != value)
                {
                    isOpinionesVisible = value;
                    OnPropertyChanged(nameof(IsOpinionesVisible));
                }
            }
        }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                if (_isFavorite != value)
                {
                    _isFavorite = value;
                    OnPropertyChanged(nameof(IsFavorite));
                }
            }
        }
        public string CalificacionPromedio
        {
            get
            {
                if (Opiniones == null || Opiniones.Count == 0)
                    return new string('☆', 5); // 5 estrellas vacías

                double promedio = Opiniones.Average(op => op.Calificacion);
                return ObtenerEstrellas(promedio);
            }
        }
        public ICommand MostrarDatosCommand { get; set; }
        public ICommand MostrarOpinionesCommand { get; set; }

        public DetalleProductoViewModel(int productId)
        {
         
            Productovisualizado = ObtenerProductoPorId(productId);
            Opiniones = ObtenerOpinionesProducto(productId);
            MostrarDatosCommand = new Command(MostrarDatos);
            MostrarOpinionesCommand = new Command(MostrarOpiniones);
            IsFavorite = WishlistService.Instance.IsInWishList(Productovisualizado);
        }
        private Product ObtenerProductoPorId(int id)
        {
            return AppData.Instance.ListProductsBD.FirstOrDefault(p => p.Id == id);
        }

        //metodo para obtener colleccion de opiniones según el id del producto
        public ObservableCollection<Opinion> ObtenerOpinionesProducto(int idProducto)
        {
            return new ObservableCollection<Opinion>(Productovisualizado.Opiniones);
        }

        // Métodos para alternar vistas
        private void MostrarDatos()
        {
            IsDatosVisible = true;
            IsOpinionesVisible = false;

            // Llama al método para cambiar el estilo de los botones
            CambiarColorBotones();
        }

        private void MostrarOpiniones()
        {
            IsDatosVisible = false;
            IsOpinionesVisible = true;

            // Llama al método para cambiar el estilo de los botones
            CambiarColorBotones();
        }

        private void CambiarColorBotones()
        {
            // Aquí podrías cambiar el estilo directamente o hacerlo desde el XAML con Binding
            OnPropertyChanged(nameof(IsDatosVisible)); // Esto notificará al UI para actualizar la vista
            OnPropertyChanged(nameof(IsOpinionesVisible)); // Lo mismo para Opiniones
        }


        // Método para alternar la inclusión del producto en la lista de deseos
        public void ToggleWishList()
        {
            if (IsFavorite)
            {
                WishlistService.Instance.RemoveFromWishList(Productovisualizado);
            }
            else
            {
                WishlistService.Instance.AddToWishList(Productovisualizado);
            }

            IsFavorite = WishlistService.Instance.IsInWishList(Productovisualizado);
        }

        // Método que devuelve una cadena de 5 estrellas basadas en el promedio
        private string ObtenerEstrellas(double promedio)
        {
            int estrellasLlenas = (int)Math.Floor(promedio);
            int estrellasVacías = 5 - estrellasLlenas;
            return new string('★', estrellasLlenas) + new string('☆', estrellasVacías);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
