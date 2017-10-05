using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BuscaCamping.DataAccess.Modelo
{
    public class Camping
    {
   

        public Camping()
        {

        }

        public Camping(int idCamping, string nombreCamping, int cantParcelas, string calle, int numeroCalle, string email,int telFijo,int celular, int idDatosCamping, int idLocalidad, int idDepartamento, int idProvincia, string nombreLocalidad, string nombreDepartamento, string nombreProvincia)
        {
            IdCamping = idCamping;
            NombreCamping = nombreCamping;
            CantParcelas = cantParcelas;
            Calle = calle;
            NumeroCalle = numeroCalle;
            Email = email;
            TelFijo = telFijo;
            Celular = celular;
            IdDatosCamping = idDatosCamping;
            IdLocalidad = idLocalidad;
            IdDepartamento = idDepartamento;
            IdProvincia = idProvincia;
            NombreLocalidad = nombreLocalidad;
            NombreDepartamento = nombreDepartamento;
            NombreProvincia = nombreProvincia;
            ListaServicios = new List<ServicioPorCamping>();
            IdServicio = 0;
            DescripcionServicio = "";
            Precio = 0;
          
            
        }

        [Display(Name = "Código")]
        public int IdCamping { get; set; }
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo letras")]
        [Required(ErrorMessage = "Por favor ingrese nombre")]
        public string NombreCamping { get; set; }
        [Display(Name = "Parcelas")]
        public int CantParcelas { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo letras")]
        [Required(ErrorMessage = "Por favor ingrese calle")]
        public string Calle { get; set; }
        [Display(Name = "Número")]
        public int NumeroCalle { get; set; }
        public int IdDatosCamping { get; set; }
        [Required(ErrorMessage = "Por favor ingrese email")]
        [RegularExpression(@"\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*", ErrorMessage = "Ingrese email valido")]
        public string Email { get; set; }
        [Display(Name = "Tel Fijo")]
        public int TelFijo { get; set; }
        public int Celular { get; set; }
        [Display(Name = "Localidad")]
        [Required(ErrorMessage = "Elija una localidad")]
        public int IdLocalidad { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Elija departamento")]
        public int IdDepartamento { get; set; }
        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Elija una provincia")]
        public int IdProvincia { get; set; }
        [Display(Name = "Localidad")]
        public string NombreLocalidad { get; set; }
        [Display(Name = "Departamento")]
        public string NombreDepartamento { get; set; }
        [Display(Name = "Provincia")]
        public string NombreProvincia { get; set; }
        public List<ServicioPorCamping> ListaServicios { get; set; }
        public int IdServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public float Precio { get; set; }
       
    }
}
