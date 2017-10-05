using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BuscaCamping.DataAccess.Modelo;

namespace BuscaCamping.DataAccess.DataReaders
{
    public class GestorZonas
    {

        SqlConnection conn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping");


        public List<Provincia> ObtenerProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();

            conn.Open();

            SqlCommand comm = new SqlCommand("Select * from provincia p", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                provincias.Add(new Provincia
                {
                    IdProvincia = dr.GetInt32(0),
                    NombreProvincia=dr.GetString(1)
                 
                });
            }

            conn.Close();
            return provincias;
        }


        public List<Departamento> ObtenerDepartamentos(int id)
        {
            List<Departamento> departamentos = new List<Departamento>();

            conn.Open();

            SqlCommand comm = new SqlCommand("select * from Departamento d join Provincia p on p.idProvincia=d.idProvincia where p.idProvincia=@id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                departamentos.Add(new Departamento
                {
                    IdDepartamento = dr.GetInt32(0),
                    NombreDepartamento = dr.GetString(1),
                    IdProvincia = dr.GetInt32(2)

                });
            }

            conn.Close();
            return departamentos;
        }

        public List<Localidad> ObtenerLocalidades(int id)
        {
            List<Localidad> localidades = new List<Localidad>();

            conn.Open();

            SqlCommand comm = new SqlCommand("select * from Localidad l join Departamento d on d.idDepartamento=l.idDepartamento where d.idDepartamento=@id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                localidades.Add(new Localidad
                {
                    IdLocalidad = dr.GetInt32(0),
                    NombreLocalidad = dr.GetString(1),
                    IdDepartamento=dr.GetInt32(2)

                });
            }

            conn.Close();
            return localidades;
        }

    }
}
