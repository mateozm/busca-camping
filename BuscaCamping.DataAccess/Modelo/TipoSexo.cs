using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
   public class TipoSexo
    {
        public TipoSexo(int idTipoSexo, string descripcion)
        {
            IdTipoSexo = idTipoSexo;
            Descripcion = descripcion;
        }

        public TipoSexo()
        {

        }

        public int IdTipoSexo { get; set; }
        public string Descripcion { get; set; }
    }
}
