using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.DTO;
using BuscaCamping.DataAccess.ViewModels;

namespace BuscaCamping.DataAccess.DataReaders
{
   public class GestorReserva
    {
        SqlConnection conn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping");

        public List<Reserva> ObtenerListaReservas()
        {
            List<Reserva> listaReservas = new List<Reserva>();

            conn.Open();

            SqlCommand comm = new SqlCommand("Select r.idReserva,r.fechaReserva,r.idCliente,r.idCamping,r.isActive from Reserva r join DetalleReserva d on d.idReserva=r.idReserva where d.idDetalleReserva>0", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                listaReservas.Add(new Reserva
                {
                    
                    IdReserva=dr.GetInt32(0),
                    FechaReserva=dr.GetDateTime(1),
                    IdCamping=dr.GetInt32(2),                   
                    IdCliente=dr.GetInt32(3),                    
                    IsActive=dr.GetBoolean(4)

                });
            }

            conn.Close();
            return listaReservas;
        }

        public DetalleReserva ObtenerReserva(int id)
        {
            DetalleReserva det = null;

            conn.Open();

            SqlCommand comm = new SqlCommand("Select distinct d.idDetalleReserva, d.cantPersonas,d.fechaIngreso,d.fechaSalida,d.idReserva, r.fechaReserva,r.idCamping,c.nombreCamping, r.idCliente,cl.nombre, r.isActive from DetalleReserva d join Reserva r on r.idReserva=d.idReserva join Servicio s on s.idServicio=d.idServicio join Camping c on c.idCamping=r.idCamping join cliente cl on cl.codCliente=r.idCliente where d.idReserva=@id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                int detalleReserva = dr.GetInt32(0);
                int cantPersonas = dr.GetInt32(1);
                DateTime fechaIng = dr.GetDateTime(2);
                DateTime fechaSal = dr.GetDateTime(3);
                int idReserva = dr.GetInt32(4);
                DateTime fechaRes = dr.GetDateTime(5);
                int idCamp = dr.GetInt32(6);
                string nombreCamp = dr.GetString(7);
                int idCliente = dr.GetInt32(8);
                string nombreCli = dr.GetString(9);
                bool isActive = dr.GetBoolean(10);

                det = new DetalleReserva(detalleReserva, cantPersonas, fechaIng, fechaSal, idReserva, fechaRes, idCamp, nombreCamp, idCliente, nombreCli, isActive);

            }

            conn.Close();
            return det;
        }


        public void AgregarReserva(DetalleReservaViewModel rvm)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("insert into Reserva (idCliente,idCamping) values (@idCliente,@idCamping) ", conn);
            comm.Parameters.Add(new SqlParameter("@idcliente", rvm.DetalleReserva.IdCliente));
            comm.Parameters.Add(new SqlParameter("@idCamping", rvm.Camping.IdCamping));
            
            comm.ExecuteNonQuery();

            conn.Close();
        }

        public void AgregarDetalleReserva(DetalleReservaDto dr)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("insert into DetalleReserva(idServicio,precio,cantPersonas,fechaIngreso,fechaSalida,idReserva) values(@idServicio,@precio,@cantPersonas,@fechaIngreso,@fechaSalida,@idReserva)", conn);
            comm.Parameters.Add(new SqlParameter("@idServicio", dr.IdServicio));
            comm.Parameters.Add(new SqlParameter("@precio", dr.Precio));
            comm.Parameters.Add(new SqlParameter("@cantPersonas", dr.CantPersonas));
            comm.Parameters.Add(new SqlParameter("@fechaIngreso", dr.FechaIngreso));
            comm.Parameters.Add(new SqlParameter("@fechaSalida", dr.FechaSalida));
            comm.Parameters.Add(new SqlParameter("@idReserva", dr.IdReserva));


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

        public Reserva ObtenerUltimaReserva()
        {
            Reserva r = null;
            conn.Open();

            SqlCommand comm = new SqlCommand("select top 1 r.idReserva,r.fechaReserva,r.idCliente,r.idCamping,r.isActive from Reserva r order by r.idReserva desc", conn);
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                int IdReserva = dr.GetInt32(0);
                DateTime FechaReserva = dr.GetDateTime(1);
                int IdCliente = dr.GetInt32(2);
                int IdCamping = dr.GetInt32(3);
                bool IsActive = dr.GetBoolean(4);



                r = new Reserva(IdReserva, FechaReserva, IdCliente, IdCamping, IsActive);
            }

            conn.Close();
            return r;
        }


   
        public List<DetalleReservaDto> ObtenerDetallePorReserva(int id)
        {
            List<DetalleReservaDto> listaDetalles = new List<DetalleReservaDto>();

            conn.Open();

            SqlCommand comm = new SqlCommand("select dr.idServicio,s.descripcion,dr.precio,dr.cantPersonas,dr.fechaIngreso,dr.fechaSalida,dr.idReserva from DetalleReserva dr join Servicio s on s.idServicio=dr.idServicio where dr.idReserva=@id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                listaDetalles.Add(new DetalleReservaDto
                {
                    IdServicio = dr.GetInt32(0),
                    Descripcion=dr.GetString(1),
                    Precio=dr.GetFloat(2),
                    CantPersonas=dr.GetInt32(3),
                    FechaIngreso=dr.GetDateTime(4),
                    FechaSalida=dr.GetDateTime(5),
                    IdReserva=dr.GetInt32(6)

                });
            }

            conn.Close();
            return listaDetalles;
        }

        public void Transaction(int CodCliente ,int IdCamping, Detalles detalles)
        {
            using (SqlConnection cn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping"))
            {
                cn.Open();
                using (SqlTransaction tr = cn.BeginTransaction())
                {
                    SqlCommand comm = new SqlCommand("insert into Reserva (idCliente,idCamping) values (@idCliente,@idCamping); Select scope_identity();", cn,tr);
                    
                    comm.Parameters.Add(new SqlParameter("@idcliente", CodCliente));
                    comm.Parameters.Add(new SqlParameter("@idCamping",IdCamping));


                    //int id=(int) comm.ExecuteScalar();
                    var id = comm.ExecuteScalar();


                    foreach(DetalleReservaDto o  in detalles.values) { 

                    SqlCommand comm1 = new SqlCommand("insert into DetalleReserva(idServicio,precio,cantPersonas,fechaIngreso,fechaSalida,idReserva) values(@idServicio,@precio,@cantPersonas,@fechaIngreso,@fechaSalida,@idReserva)", cn,tr);
                    comm1.Parameters.Add(new SqlParameter("@idServicio", o.IdServicio));
                    comm1.Parameters.Add(new SqlParameter("@precio", o.Precio));
                    comm1.Parameters.Add(new SqlParameter("@cantPersonas", o.CantPersonas));
                    comm1.Parameters.Add(new SqlParameter("@fechaIngreso", o.FechaIngreso));
                    comm1.Parameters.Add(new SqlParameter("@fechaSalida", o.FechaSalida));
                    comm1.Parameters.Add(new SqlParameter("@idReserva", id));

                    comm1.ExecuteNonQuery();
                    }
                    tr.Commit();
                }
            }
        }




    }
}
