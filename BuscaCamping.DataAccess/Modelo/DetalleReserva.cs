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


        public DetalleReserva()
        {

        }

        public DetalleReserva(int idDetalleReserva, int cantPersonas, DateTime fechaIngreso, DateTime fechaSalida, int idReserva, DateTime fechaReserva, int idCamping, string nombreCamping, int idCliente, string nombreCliente, bool isActive)
        {
            IdDetalleReserva = idDetalleReserva;            
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
            IdServicio = 0;
            Descripcion = "";
            Precio = 0;
            
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
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [Display(Name = "Fecha Sal.")]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }
        [Display(Name = "Cod. Res.")]
        public int IdReserva { get; set; }
        [Display(Name = "Fecha Res.")]
        [DataType(DataType.Date)]
        public DateTime FechaReserva { get; set; }
        [Display(Name = "Cod. Camping")]
        public int IdCamping { get; set; }
        [Display(Name = "Camping")]
        public string NombreCamping { get; set; }
        [Display(Name = "Cliente N°")]
        public int IdCliente { get; set; }
        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; }
        [Display(Name = "Activa")]
        public bool IsActive { get; set; }

       



    }
}
