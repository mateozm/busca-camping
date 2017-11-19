using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.ViewModels;
using BuscaCamping.DataAccess.DTO;

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



        public void AgregarServicioPorCamp(ServiciosPorCampingDto svm)
        {
            conn.Open();           

                SqlCommand comm = new SqlCommand("insert into ServicioPorCamping(idCamping,idServicio,precio)values (@idCamping,@idServicio,@precio) ", conn);
                comm.Parameters.Add(new SqlParameter("@idCamping", svm.idCamping));
                comm.Parameters.Add(new SqlParameter("@idServicio", svm.idServicio));
                comm.Parameters.Add(new SqlParameter("@precio", svm.precio));

                comm.ExecuteNonQuery();

                conn.Close();
            
        }

        public List<ServicioPorCamping> ObtenerListaServiciosPorCamping(int id)
        {
            List<ServicioPorCamping> listaServiciosPorCamping = new List<ServicioPorCamping>();
            conn.Open();

            SqlCommand comm = new SqlCommand("select sc.idServicioPorCamping,sc.idCamping,sc.idServicio,sc.precio, c.nombreCamping, s.descripcion from ServicioPorCamping sc join Camping c on c.idCamping=sc.idCamping join Servicio s on s.idServicio=sc.idServicio where sc.idCamping=@id ", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                listaServiciosPorCamping.Add(new ServicioPorCamping
                {
                 IdServicioPorCamping = dr.GetInt32(0),
                 IdCamping = dr.GetInt32(1),
                 IdServicio = dr.GetInt32(2),
                 Precio = dr.GetFloat(3),
                 NombreCamping = dr.GetString(4),
                 DescripcionServ = dr.GetString(5)
            });
        }
            conn.Close();
            return listaServiciosPorCamping;
        }

        public void EliminarServicio(int id)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("delete from ServicioPorCamping where idServicioPorCamping = @id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));

            comm.ExecuteNonQuery();
            conn.Close();
        }

        public ServicioPorCamping ObtenerServPorCamp(int id)
        {
            ServicioPorCamping spc = null;
            conn.Open();

            SqlCommand comm = new SqlCommand("select sc.idServicioPorCamping,sc.idCamping,sc.idServicio,sc.precio, c.nombreCamping, s.descripcion from ServicioPorCamping sc join Camping c on c.idCamping=sc.idCamping join Servicio s on s.idServicio=sc.idServicio where sc.idServicioPorCamping=@id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                int IdServPorCamp = dr.GetInt32(0);
                int IdCamping = dr.GetInt32(1);
                int IdServicio = dr.GetInt32(2);
                float Precio = dr.GetFloat(3);
                string NombreCamping = dr.GetString(4);
                string Descripcion = dr.GetString(5);

                spc = new ServicioPorCamping(IdServPorCamp, IdCamping, IdServicio, Precio, NombreCamping, Descripcion);               
            }

            conn.Close();
            return spc;
        }


        public void EditarServicio(ServicioPorCamping spc)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("update ServicioPorCamping set precio=@Precio where idServicioPorCamping=@id", conn);
            comm.Parameters.Add(new SqlParameter("@Precio", spc.Precio));
            comm.Parameters.Add(new SqlParameter("@id", spc.IdServicioPorCamping));

            comm.ExecuteNonQuery();
            conn.Close();
        }



        public List<ServicioAlojamiento> ObtenerListaServiciosAlojamiento(int id)
        {
            List<ServicioAlojamiento> listaServiciosPorReserva = new List<ServicioAlojamiento>();
            conn.Open();

            SqlCommand comm = new SqlCommand("select s.idServicio,s.descripcion,sc.precio from Servicio s join ServicioPorCamping sc on sc.idServicio=s.idServicio where sc.idServicio between 1 and 3 and sc.idCamping=@id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                listaServiciosPorReserva.Add(new ServicioAlojamiento
                {
                    IdServicio = dr.GetInt32(0),
                    Descripcion = dr.GetString(1),
                    Precio=dr.GetFloat(2)
                });
            }
            conn.Close();
            return listaServiciosPorReserva;
        }



    }
}
