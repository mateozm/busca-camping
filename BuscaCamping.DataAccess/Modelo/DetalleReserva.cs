using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BuscaCamping.DataAccess.Modelo
{
    public class DetalleReserva
    {   

        public DetalleReserva(int idDetalleReserva, int idServicio, string descripcion, float precio, int cantPersonas, DateTime fechaIngreso, DateTime fechaSalida, int idReserva, DateTime fechaReserva, int idCamping, string nombreCamping, int idCliente, string nombreCliente, bool isActive)
        {
            IdDetalleReserva = idDetalleReserva;
            IdServicio = idServicio;
            Descripcion = descripcion;
            Precio = precio;
            CantPersonas = cantPersonas;
            FechaIngreso = fechaIngreso;
            FechaSalida = fechaSalida;
            IdReserva = idReserva;
            FechaReserva = fechaReserva;
            IdCamping = idCamping;
            NombreCamping = nombreCamping;
            IdCliente = idCliente;
            NombreCliente = nombreCliente;
            IsActive = isActive;
        }

        public DetalleReserva()
        {

        }
        [Display(Name = "Código")]
        public int IdDetalleReserva { get; set; }
        [Display(Name = "Servicio")]
        public int IdServicio { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        [Display(Name = "Cant Personas")]
        public int CantPersonas { get; set; }
        [Display(Name = "Fecha Ing.")]
        public DateTime FechaIngreso { get; set; }
        [Display(Name = "Fecha Sal.")]
        public DateTime FechaSalida { get; set; }
        [Display(Name = "Cod. Res.")]
        public int IdReserva { get; set; }
        [Display(Name = "Fecha Res.")]
        public DateTime FechaReserva { get; set; }
        [Display(Name = "Cod. Camping")]
        public int IdCamping { get; set; }
        [Display(Name = "Camping")]
        public string NombreCamping { get; set; }
        [Display(Name = "Cod. Cli.")]
        public int IdCliente { get; set; }
        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; }
        [Display(Name = "Fecha Ing")]
        public bool IsActive { get; set; }



    }
}
