using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
    public class Reserva
    {
        public Reserva(int idReserva, DateTime fechaReserva, int idCliente, int idCamping, bool isActive)
        {
            IdReserva = idReserva;
            FechaReserva = fechaReserva;
            IdCliente = idCliente;
            IdCamping = idCamping;
            IsActive = isActive;
        }
        public Reserva()
        {

        }

        [Display(Name = "Cod. Reserva")]
        public int IdReserva { get; set; }
        [Display(Name = "Fecha Reserva")]
        public DateTime FechaReserva { get; set; }
        [Display(Name = "Cod. Cliente")]
        public int IdCliente { get; set; }
        [Display(Name = "Cod. Camping")]
        public int IdCamping { get; set; }
        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        public string estadoReserva()
        {
            string estado = "";
            if (IsActive == false)
            {
                estado = "Cancelada";
            }
            else
            {
                estado = "Activa";
            }
            return estado;
        }
    }
}
