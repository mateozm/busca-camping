using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
    public class ServicioCamping
    {
        public ServicioCamping(int idServicio, string descripcion)
        {
            IdServicio = idServicio;
            Descripcion = descripcion;
            
            
        }

        public ServicioCamping()
        {

        }

        public int IdServicio { get; set; }
        public string Descripcion { get; set; }
        
    }
}
