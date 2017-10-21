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

            SqlCommand comm = new SqlCommand("insert into Reserva(idCliente,idCamping) values (@idcliente,@idCamping)", conn);
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

        //public List<DetalleReserva> ObtenerListaReservas()
        //{
        //    List<DetalleReserva> listaReservas = new List<DetalleReserva>();

        //    conn.Open();

        //    SqlCommand comm = new SqlCommand("", conn);
        //    SqlDataReader dr = comm.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        listaReservas.Add(new DetalleReserva
        //        {
        //            IdDetalleReserva = dr.GetInt32(0),
        //            IdServicio= dr.GetInt32(1),
        //            Precio = dr.GetFloat(2),
        //            CantPersonas = dr.GetInt32(3),
        //            FechaIngreso = dr.GetDateTime(4),
        //            FechaSalida = dr.GetDateTime(5),
        //            IdReserva = dr.GetInt32(6),
        //            FechaReserva=dr.GetDateTime(7),
        //            IdCamping = dr.GetInt32(8),
        //            IdCliente = dr.GetInt32(9),
        //            IsActive= dr.GetBoolean(10)

        //    });
        //    }

        //    conn.Close();
        //    return listaReservas;
        //}

        //public DetalleReserva ObtenerReserva(int id)
        //{
        //    Camping c = null;
        //    conn.Open();

        //    SqlCommand comm = new SqlCommand("select c.idCamping,c.nombreCamping,c.cantParcelas,c.calle,c.numeroCalle,dc.email,dc.telFijo,dc.celular,c.idDatosCamping ,c.idLocalidad,l.idDepartamento,d.idProvincia,  l.nombreLocalidad, d.nombreDepartamento, p.nombreProvincia from Camping c join DatosCamping dc on dc.idDatosCamping=c.idDatosCamping join Localidad l on c.idLocalidad=l.idLocalidad join Departamento d on d.idDepartamento=l.idDepartamento join Provincia p on p.idProvincia=d.idProvincia where c.idCamping = @id", conn);
        //    comm.Parameters.Add(new SqlParameter("@id", id));
        //    SqlDataReader dr = comm.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        int IdCamping = dr.GetInt32(0);
        //        string NombreCamping = dr.GetString(1);
        //        int CantParcelas = dr.GetInt32(2);
        //        string Calle = dr.GetString(3);
        //        int NumeroCalle = dr.GetInt32(4);
        //        string Email = dr.GetString(5);
        //        int TelFijo = dr.GetInt32(6);
        //        int Celular = dr.GetInt32(7);
        //        int IdDatosCamping = dr.GetInt32(8);
        //        int IdLocalidad = dr.GetInt32(9);
        //        int IdDepartamento = dr.GetInt32(10);
        //        int IdProvincia = dr.GetInt32(11);
        //        string NombreLocalidad = dr.GetString(12);
        //        string NombreDepartamento = dr.GetString(13);
        //        string NombreProvincia = dr.GetString(14);


        //        c = new Camping(IdCamping, NombreCamping, CantParcelas, Calle, NumeroCalle, Email, TelFijo, Celular, IdDatosCamping, IdLocalidad, IdDepartamento, IdProvincia, NombreLocalidad, NombreDepartamento, NombreProvincia);
        //    }

        //    conn.Close();
        //    return c;
        //}




    }
}
