using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
    public class ServicioCamping
    {
        public ServicioCamping(int idServicio, string descripcion, int precio)
        {
            IdServicio = idServicio;
            Descripcion = descripcion;
            Precio = precio;
            
        }

        public ServicioCamping()
        {

        }

        public int IdServicio { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public bool IsChecked { get; set; }
    }
}
