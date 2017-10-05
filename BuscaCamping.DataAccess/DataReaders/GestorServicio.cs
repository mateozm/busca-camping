using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.ViewModels;

namespace BuscaCamping.DataAccess.DataReaders
{
    public class GestorServicio
    {
        SqlConnection conn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping");
        
        public List<ServicioCamping> ObtenerTodosServicios()
        {
            List<ServicioCamping> servicios = new List<ServicioCamping>();

            conn.Open();

            SqlCommand comm = new SqlCommand("Select * from servicio s", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                servicios.Add(new ServicioCamping
                {
                    IdServicio = dr.GetInt32(0),
                    Descripcion = dr.GetString(1)

                });
            }

            conn.Close();
            return servicios;
        }

        public void AgregarServicioPorCamp(ServicioViewModel svm)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("insert into ServicioPorCamping(idCamping,idServicio,precio)values (@idCamping,@idServicio,@precio) ", conn);
            comm.Parameters.Add(new SqlParameter("@idCamping", svm.ServPorCam.IdCamping));
            comm.Parameters.Add(new SqlParameter("@idServicion", svm.ServPorCam.IdServicio));
            comm.Parameters.Add(new SqlParameter("@precio", svm.ServPorCam.Precio));

            comm.ExecuteNonQuery();

            conn.Close();
        }



    }
}
