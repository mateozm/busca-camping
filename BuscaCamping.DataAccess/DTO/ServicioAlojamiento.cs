using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.DTO
{
    public class ServicioAlojamiento
    {
        public ServicioAlojamiento(int idServicio, string descripcion, float precio)
        {
            IdServicio = idServicio;
            Descripcion = descripcion;
            Precio = precio;
        }

        public ServicioAlojamiento()
        {

        }

        public int IdServicio { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }
}
