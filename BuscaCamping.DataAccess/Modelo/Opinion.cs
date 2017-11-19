using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
    public class Opinion
    {
        

        public Opinion()
        {

        }

        public Opinion(int idOpinion, int idCamping, string nombreCamping, string texto, string idUser, int calificacion)
        {
            IdOpinion = idOpinion;
            IdCamping = idCamping;
            NombreCamping = nombreCamping;
            Texto = texto;
            IdUser = idUser;
            Calificacion = calificacion;
        }

        public int IdOpinion { get; set; }
        public int IdCamping { get; set; }
        [Display(Name = "Camping")]
        public string NombreCamping { get; set; }
        [Display(Name = "Opinión")]
        public string Texto { get; set; }
        public string IdUser { get; set; }
        public int Calificacion { get; set; }
    }
}
