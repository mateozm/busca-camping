using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BuscaCamping.DataAccess.Modelo
{
   public class Cliente
    {
    

        public Cliente()
        {

        }

        public Cliente(int codCliente, int dni, string nombre, string apellido, DateTime fechaNac, bool nacionalidad, int idTipoSexo, int idLocalidad, string calle, int numeroCalle, int idDatosContacto, string email, int telFijo, int celular, string nombreLocalidad, string nombreDepartamento, string nombreProvincia, string descripcionSexo, int idProvincia, int idDepartamento)
        {
            CodCliente = codCliente;
            Dni = dni;
            Nombre = nombre;
            Apellido = apellido;
            FechaNac = fechaNac;
            Nacionalidad = nacionalidad;
            IdTipoSexo = idTipoSexo;                       
            Calle = calle;
            NumeroCalle = numeroCalle;
            IdDatosContacto = idDatosContacto;
            Email = email;
            TelFijo = telFijo;
            Celular = celular;
            NombreLocalidad = nombreLocalidad;
            NombreDepartamento = nombreDepartamento;
            NombreProvincia = nombreProvincia;
            DescripcionSexo = descripcionSexo;                 
            IdLocalidad = idLocalidad;
            IdProvincia = idProvincia;       
            IdDepartamento = idDepartamento;
        }
        [Display(Name = "Código")]
        public int CodCliente { get; set; }
        public int Dni { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo letras")]
        [Required(ErrorMessage ="Por favor ingrese su nombre")]
        public string Nombre { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Solo letras")]
        [Required]
        public string Apellido { get; set; }
        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNac { get; set; }
        public bool Nacionalidad { get; set; }
        [Display(Name = "Sexo")]
        public int IdTipoSexo { get; set; }
        [Display(Name = "Localidad")]
        [Required(ErrorMessage ="Elija una localidad")]
        public int IdLocalidad { get; set; }
        [Required]
        public string Calle { get; set; }
        [Display(Name = "Número")]
        public int NumeroCalle { get; set; }
        public int IdDatosContacto { get; set; }
        [Required]
        [RegularExpression(@"\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*", ErrorMessage = "Ingrese email valido")]
        public string Email { get; set; }
        [Display(Name = "Tel. Fijo")]
        public int TelFijo{ get; set; }
        [Display(Name = "Celular")]
        public int Celular { get; set; }
        [Display(Name = "Localidad")]
        public string NombreLocalidad { get; set; }
        [Display(Name = "Departamento")]
        public string NombreDepartamento { get; set; }
        [Display(Name = "Provincia")]
        public string NombreProvincia { get; set; }
        [Display(Name = "Sexo")]
        public string DescripcionSexo { get; set; }
        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Elija una provincia")]
        public int IdProvincia { get; set; }
        [Display(Name = "Departamento")]        
        [Required(ErrorMessage = "Elija departamento")]
        public int IdDepartamento { get; set; }

        

        public string ObtenerNacionalidad()
        {
            string res = "";
            if (Nacionalidad == true)
            {
                res = "Argentino";
            }else
            {
                res = "Extranjero";
            }
            return res;
        }
        




    }
}
