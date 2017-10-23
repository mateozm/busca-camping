using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.DTO;

namespace BuscaCamping.DataAccess.ViewModels
{
    public class ReservaViewModel
    {
       public DetalleReserva DetalleReserva { get; set; }
       public List<DetalleReserva> ListaReservas { get; set; }
       public List<ServicioCamping> ListaServiciosAlojamiento { get; set; }
       public List<ServicioPorReserva> ListaServicioPorReserva { get; set; } 
    }
}
