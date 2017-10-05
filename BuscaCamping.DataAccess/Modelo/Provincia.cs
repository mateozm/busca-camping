using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
    public class Provincia
    {
        public Provincia(int idProvincia, string nombreProvincia)
        {
            IdProvincia = idProvincia;
            NombreProvincia = nombreProvincia;
        }

        public Provincia()
        {

        }

        public int IdProvincia { get; set; }
        public string NombreProvincia { get; set; }

      
    }
}
