using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaCamping.DataAccess.Modelo;

namespace BuscaCamping.DataAccess.ViewModels
{
    public class ReservaViewModel
    {
       public DetalleReserva DetalleReserva { get; set; }
       public List<ServicioCamping> servicios { get; set; } 
    }
}
