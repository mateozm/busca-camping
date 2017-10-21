using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.DTO
{
    public class Busqueda
    {
        
        public string NombreBusqueda;

        public Busqueda( string nombre)
        {
            
            NombreBusqueda = nombre;
        }

        public Busqueda()
        {

        }
    }
}
