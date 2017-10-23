using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.DTO
{
    public class ServicioPorReserva
    {
        public ServicioPorReserva(int idServicio, string descripcion, float precio, int cantPersonas)
        {
            IdServicio = idServicio;
            Descripcion = descripcion;
            Precio = precio;
            CantPersonas = cantPersonas;
        }

        public ServicioPorReserva()
        {

        }

        public int IdServicio { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int CantPersonas { get; set; }
    }
}
