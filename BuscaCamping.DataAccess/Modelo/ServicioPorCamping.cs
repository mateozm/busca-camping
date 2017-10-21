using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BuscaCamping.DataAccess.Modelo
{
    public class ServicioPorCamping
    {     

        public ServicioPorCamping(int idServicioPorCamping, int idCamping, int idServicio, float precio, string nombreCamping, string descripcionServ)
        {
            IdServicioPorCamping = idServicioPorCamping;
            IdCamping = idCamping;
            IdServicio = idServicio;
            Precio = precio;
            NombreCamping = nombreCamping;
            DescripcionServ = descripcionServ;
        }

        public ServicioPorCamping()
        {

        }
        [Display(Name = "Código")]
        public int IdServicioPorCamping { get; set; }
        public int IdCamping { get; set; }
        public int IdServicio { get; set; }
        public float Precio { get; set; }
        [Display(Name = "Camping")]
        public string NombreCamping { get; set; }
        [Display(Name = "Servicio")]
        public string DescripcionServ { get; set; }
        
    }

    
}
