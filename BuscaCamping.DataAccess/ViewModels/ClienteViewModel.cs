using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuscaCamping.DataAccess.Modelo;

namespace BuscaCamping.DataAccess.ViewModels
{
   public class ClienteViewModel
    {
        public Cliente cliente { get; set; }     
        public List<Localidad> localidades { get; set; }
        public List<Departamento> departamentos { get; set; }
        public List<Provincia> provincias { get; set; }
        public List<TipoSexo> sexos { get; set; }
    }
}
