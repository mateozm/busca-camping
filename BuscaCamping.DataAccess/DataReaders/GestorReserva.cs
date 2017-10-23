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
   public class GestorReserva
    {
        SqlConnection conn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping");

        public void AgregarReserva(ReservaViewModel rvm)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("insert into Reserva (idCliente,idCamping) values (@idCliente,@idCamping) ", conn);
            comm.Parameters.Add(new SqlParameter("@idcliente", rvm.DetalleReserva.IdCliente));
            comm.Parameters.Add(new SqlParameter("@idCamping", rvm.DetalleReserva.IdCamping));
            
            comm.ExecuteNonQuery();

            conn.Close();
        }

        public void AgregarDetalleReserva(ReservaViewModel rvm)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("insert into DetalleReserva(idServicio,precio,cantPersonas,fechaIngreso,fechaSalida,idReserva) values(@idServicio,@precio,@cantPersonas,@fechaIngreso,@fechaSalida,@idReserva)", conn);
            comm.Parameters.Add(new SqlParameter("@idServicio", rvm.DetalleReserva.IdServicio));
            comm.Parameters.Add(new SqlParameter("@precio", rvm.DetalleReserva.Precio));
            comm.Parameters.Add(new SqlParameter("@cantPersonas", rvm.DetalleReserva.CantPersonas));
            comm.Parameters.Add(new SqlParameter("@fechaIngreso", rvm.DetalleReserva.FechaIngreso));
            comm.Parameters.Add(new SqlParameter("@fechaSalida", rvm.DetalleReserva.FechaSalida));
            comm.Parameters.Add(new SqlParameter("@idReserva", rvm.DetalleReserva.IdReserva));


            comm.ExecuteNonQuery();

            conn.Close();
        }


        public void CancelarReserva(int id)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("Update Reserva set isActive=0 where idReserva= @id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));

            comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<DetalleReserva> ObtenerListaReservas()
        {
            List<DetalleReserva> listaReservas = new List<DetalleReserva>();

            conn.Open();

            SqlCommand comm = new SqlCommand("Select d.idDetalleReserva,d.idServicio,d.precio,d.cantPersonas,d.fechaIngreso,d.fechaSalida,d.idReserva, r.fechaReserva,r.idCliente,r.idCamping,r.isActive from DetalleReserva d join Reserva r on r.idReserva=d.idDetalleReserva", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                listaReservas.Add(new DetalleReserva
                {
                    IdDetalleReserva = dr.GetInt32(0),
                    IdServicio = dr.GetInt32(1),
                    Precio = dr.GetFloat(2),
                    CantPersonas = dr.GetInt32(3),
                    FechaIngreso = dr.GetDateTime(4),
                    FechaSalida = dr.GetDateTime(5),
                    IdReserva = dr.GetInt32(6),
                    FechaReserva = dr.GetDateTime(7),
                    IdCamping = dr.GetInt32(8),
                    IdCliente = dr.GetInt32(9),
                    IsActive = dr.GetBoolean(10)

                });
            }

            conn.Close();
            return listaReservas;
        }

        public DetalleReserva ObtenerReserva(int id)
        {
            DetalleReserva ds = null;
            conn.Open();

            SqlCommand comm = new SqlCommand("Select d.idDetalleReserva,d.idServicio,d.precio,d.cantPersonas,d.fechaIngreso,d.fechaSalida,d.idReserva, r.fechaReserva,r.idCliente,c.nombre,r.idCamping,cg.nombreCamping,r.isActive  from DetalleReserva d join Reserva r on r.idReserva=d.idDetalleReserva join Cliente c on c.codCliente=r.idCliente join Camping cg on cg.idCamping=r.idCamping where d.idReserva = @id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                int IdDetalleReserva = dr.GetInt32(0);
                int IdServicio = dr.GetInt32(1);
                string Descripcion = dr.GetString(2);
                float Precio = dr.GetFloat(3);
                int CantPersonas = dr.GetInt32(4);
                DateTime FechaIngreso = dr.GetDateTime(5);
                DateTime FechaSalida = dr.GetDateTime(6);
                int IdReserva = dr.GetInt32(7);
                DateTime FechaReserva = dr.GetDateTime(8);
                int IdCamping = dr.GetInt32(9);
                string NombreCamping = dr.GetString(10);
                int IdCliente = dr.GetInt32(11);
                string NombreCliente = dr.GetString(12);
                bool IsActive = dr.GetBoolean(13);



                ds = new DetalleReserva(IdDetalleReserva,IdServicio,Descripcion,Precio,CantPersonas,FechaIngreso,FechaSalida,IdReserva,FechaReserva,IdCamping,NombreCamping,IdCliente,NombreCliente,IsActive);
            }

            conn.Close();
            return ds;
        }

        public List<ServicioCamping> ObtenerServiciosAlojamiento(int id)
        {
            List<ServicioCamping> servicios = new List<ServicioCamping>();

            conn.Open();

            SqlCommand comm = new SqlCommand("select sc.idServicio, s.descripcion from ServicioPorCamping sc join Servicio s on s.idServicio=sc.idServicio where sc.idServicio between 1 and 3 and sc.idCamping=@id order by sc.idServicio asc ", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
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




    }
}
