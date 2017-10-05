using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.Modelo
{
    public class Departamento
    {
        public Departamento(int idDepartamento, string nombreDepartamento, int idProvincia)
        {
            IdDepartamento = idDepartamento;
            NombreDepartamento = nombreDepartamento;
            IdProvincia = idProvincia;
        }

        public Departamento()
        {

        }

        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int IdProvincia { get; set; }
    }
}
