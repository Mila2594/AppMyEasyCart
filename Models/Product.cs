using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEasyCart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Foto { get; set; }
        public string Description { get; set; }
        public decimal Precio { get; set; }
        public int CalificacionPromedio { get; set; }
        public List<Opinion> Opiniones { get; set; } = new List<Opinion>();


        public Product(int id, string name, string image, string description, decimal price, int calificacionPromedio = 0)
        {
            Id = id;
            Nombre = name;
            Foto = image;
            Description = description;
            Precio = price;
            CalificacionPromedio = calificacionPromedio;
        }

       
    }
}
