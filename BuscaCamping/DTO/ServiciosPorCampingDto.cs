using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuscaCamping.DTO
{
    public class ServiciosPorCampingDto
    {
           public int idCamping { get; set; }
           public int idServicio { get; set; }
           public string descripcion { get; set; }
           public float precio { get; set; }
    }

    public class Servicios
    {
        public ServiciosPorCampingDto[] values { get; set; }
    }
}