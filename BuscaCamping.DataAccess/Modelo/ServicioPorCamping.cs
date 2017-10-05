using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
    public class ServicioPorCamping
    {
        public ServicioPorCamping(int idServicioPorCamping, int idCamping, int idServicio, float precio)
        {
            IdServicioPorCamping = idServicioPorCamping;
            IdCamping = idCamping;
            IdServicio = idServicio;
            Precio = precio;
        }

        public ServicioPorCamping()
        {

        }

        public int IdServicioPorCamping { get; set; }
        public int IdCamping { get; set; }
        public int IdServicio { get; set; }
        public float Precio { get; set; }
    }
}
