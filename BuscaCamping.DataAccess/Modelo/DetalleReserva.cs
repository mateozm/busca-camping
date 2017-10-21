using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
    public class DetalleReserva
    {
       

        public DetalleReserva(int idDetalleReserva, int idServicio, float precio, int cantPersonas, DateTime fechaIngreso, DateTime fechaSalida, int idReserva, DateTime fechaReserva, int idCamping, int idCliente,bool isActive)
        {
            IdDetalleReserva = idDetalleReserva;
            IdServicio = idServicio;
            Precio = precio;
            CantPersonas = cantPersonas;
            FechaIngreso = fechaIngreso;
            FechaSalida = fechaSalida;
            IdReserva = idReserva;
            FechaReserva = fechaReserva;
            IdCamping = idCamping;
            IdCliente = idCliente;
            IsActive = isActive;
        }

        public DetalleReserva()
        {

        }

        public int IdDetalleReserva { get; set; }
        public int IdServicio { get; set; }
        public float Precio { get; set; }
        public int CantPersonas { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int IdReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public int IdCamping { get; set; }
        public int IdCliente { get; set; }
        public bool IsActive { get; set; }



    }
}
