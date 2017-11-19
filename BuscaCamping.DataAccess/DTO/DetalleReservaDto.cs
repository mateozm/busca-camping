using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.DTO
{
    public class DetalleReservaDto
    {
        public DetalleReservaDto(int idServicio, string descripcion, float precio, int cantPersonas, DateTime fechaIngreso, DateTime fechaSalida, int idReserva)
        {
            IdServicio = idServicio;
            Descripcion = descripcion;
            Precio = precio;
            CantPersonas = cantPersonas;
            FechaIngreso = fechaIngreso;
            FechaSalida = fechaSalida;
            IdReserva = idReserva;
        }

        public DetalleReservaDto()
        {

        }

        public int IdServicio { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int CantPersonas { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int IdReserva { get; set; }
    }

    public class Detalles
    {
        public DetalleReservaDto[] values { get; set; }
    }
    

}
