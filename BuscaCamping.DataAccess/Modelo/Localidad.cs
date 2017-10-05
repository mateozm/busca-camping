using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuscaCamping.DataAccess.Modelo
{
    public class Localidad
    {
        public Localidad(int idLocalidad, string nombreLocalidad, int idDepartamento)
        {
            IdLocalidad = idLocalidad;
            NombreLocalidad = nombreLocalidad;
            IdDepartamento = idDepartamento;
        }

        public Localidad()
        {

        }
        
        public int IdLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public int IdDepartamento { get; set; }
    }
}
