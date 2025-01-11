using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEasyCart.Models
{
    public class Opinion
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string NombreUsuario { get; set; }
        public int Calificacion { get; set; }
        public string Fecha { get; set; }
        public string? Comentario { get; set; }

        public Opinion(int id, int idProducto, string nombreUsuario, int calificacion, string fecha, string? comentario = null)
        {
            Id = id;
            IdProducto = idProducto;
            NombreUsuario = nombreUsuario;
            Calificacion = calificacion;
            Fecha = fecha;
            Comentario = comentario;
        }

        // Propiedad que devuelve las estrellas en base a la calificación
        public string Estrellas
        {
            get
            {
                return ObtenerEstrellas(Calificacion);
            }
        }

        // Método que devuelve una cadena de 5 estrellas basadas en la calificación
        private string ObtenerEstrellas(int calificacion)
        {
            int estrellasLlenas = calificacion;
            int estrellasVacías = 5 - estrellasLlenas;
            return new string('★', estrellasLlenas) + new string('☆', estrellasVacías);
        }
    }

}
