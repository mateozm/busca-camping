using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.DTO;

namespace BuscaCamping.DataAccess.ViewModels
{
    public class DetalleReservaViewModel
    {
       public DetalleReserva DetalleReserva { get; set; }
       public Reserva Reserva { get; set; }
       public Cliente Cliente { get; set; }
       public Camping Camping { get; set; }       
       public List<ServicioAlojamiento> ListaServiciosAlojamiento { get; set; }
       public List<DetalleReservaDto> ListaDetallesPorReserva { get; set; }
       
    }
}
