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
    public class GestorCliente
    {
        SqlConnection conn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping");


        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> clientes = new List<Cliente>();

            conn.Open();

            SqlCommand comm = new SqlCommand("select c.codCliente, c.dni,c.nombre,c.apellido,c.fechaNac,c.nacionalidad,c.idTipoSexo,c.idlocalidad, c.calle,c.numeroCalle, dc.email,dc.telFijjo,dc.celular, l.nombreLocalidad,d.nombreDepartamento,p.nombreProvincia, t.descripcion from cliente c join DatosContacto dc on dc.idDatosContacto=c.idDatosContacto join TipoSexo t on t.idTipoSexo=c.idTipoSexo join Localidad l on l.idLocalidad=c.idlocalidad join Departamento d on d.idDepartamento=l.idDepartamento join Provincia p on p.idProvincia=d.idProvincia ", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                clientes.Add(new Cliente
                {
                    CodCliente=dr.GetInt32(0),
                    Dni=dr.GetInt32(1),
                    Nombre=dr.GetString(2),
                    Apellido=dr.GetString(3),
                    FechaNac=dr.GetDateTime(4),
                    Nacionalidad=dr.GetBoolean(5),
                    IdTipoSexo=dr.GetInt32(6),
                    IdLocalidad=dr.GetInt32(7),
                    Calle=dr.GetString(8),
                    NumeroCalle=dr.GetInt32(9),
                    Email=dr.GetString(10),
                    TelFijo=dr.GetInt32(11),
                    Celular = dr.GetInt32(12),
                    NombreLocalidad=dr.GetString(13),
                    NombreDepartamento = dr.GetString(14),
                    NombreProvincia = dr.GetString(15),
                    DescripcionSexo=dr.GetString(16)
                });
            }

            conn.Close();
            return clientes;
        }

        public void Eliminar(int id)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("DELETE from Cliente WHERE codCliente = @id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));

            comm.ExecuteNonQuery();
            conn.Close();
        }

        public Cliente ObtenerCliente(int id)
        {
            Cliente c = null;
            conn.Open();

            SqlCommand comm = new SqlCommand("select c.codCliente,c.dni,c.nombre,c.apellido,c.fechaNac,c.nacionalidad,c.idTipoSexo,c.idlocalidad, c.calle,c.numeroCalle,c.idDatosContacto, dc.email,dc.telFijjo,dc.celular,l.nombreLocalidad,d.nombreDepartamento,p.nombreProvincia,t.descripcion, p.idProvincia,d.idDepartamento from cliente c  join DatosContacto dc on dc.idDatosContacto=c.idDatosContacto join TipoSexo t on t.idTipoSexo=c.idTipoSexo join Localidad l on l.idLocalidad=c.idlocalidad join Departamento d on d.idDepartamento=l.idDepartamento join Provincia p on p.idProvincia=d.idProvincia where codCliente = @id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                int CodCliente = dr.GetInt32(0);
                int Dni = dr.GetInt32(1);
                string Nombre = dr.GetString(2);
                string Apellido = dr.GetString(3);
                DateTime FechaNac = dr.GetDateTime(4);
                bool Nacionalidad = dr.GetBoolean(5);
                int TipoSexo = dr.GetInt32(6);
                int IdLocalidad = dr.GetInt32(7);
                string Calle = dr.GetString(8);
                int NumeroCalle = dr.GetInt32(9);
                int IdDatosContacto = dr.GetInt32(10);
                string Email = dr.GetString(11);
                int TelFijo = dr.GetInt32(12);
                int Celular = dr.GetInt32(13);
                string NombreLocalidad = dr.GetString(14);
                string NombreDepartamento = dr.GetString(15);
                string NombreProvincia = dr.GetString(16);
                string DescripcionSexo = dr.GetString(17);
                int IdProvincia = dr.GetInt32(18);
                int IdDepartamento = dr.GetInt32(19);

                
                c = new Cliente(CodCliente,Dni,Nombre, Apellido, FechaNac,Nacionalidad,TipoSexo, IdLocalidad, Calle,NumeroCalle,IdDatosContacto, Email,TelFijo,Celular,NombreLocalidad,NombreDepartamento,NombreProvincia,DescripcionSexo,IdProvincia,IdDepartamento);
            }

            conn.Close();
            return c;
        }



        public void AgregarCliente(ClienteViewModel cvm, string idUser)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("exec procedimiento10 @email,@telFijo,@celular,@dni,@nombre,@apellido,@fechaNac,@nacionalidad,@idTipoSexo,@idLocalidad,@calle,@numeroCalle,@idUser", conn);
            comm.Parameters.Add(new SqlParameter("@email", cvm.cliente.Email));
            comm.Parameters.Add(new SqlParameter("@telFijo", cvm.cliente.TelFijo));
            comm.Parameters.Add(new SqlParameter("@celular", cvm.cliente.Celular));
            comm.Parameters.Add(new SqlParameter("@dni", cvm.cliente.Dni));
            comm.Parameters.Add(new SqlParameter("@nombre", cvm.cliente.Nombre));
            comm.Parameters.Add(new SqlParameter("@apellido", cvm.cliente.Apellido));
            comm.Parameters.Add(new SqlParameter("@fechaNac", cvm.cliente.FechaNac));
            comm.Parameters.Add(new SqlParameter("@nacionalidad", cvm.cliente.Nacionalidad));
            comm.Parameters.Add(new SqlParameter("@idTipoSexo", cvm.cliente.IdTipoSexo));
            comm.Parameters.Add(new SqlParameter("@idLocalidad", cvm.cliente.IdLocalidad));
            comm.Parameters.Add(new SqlParameter("@calle", cvm.cliente.Calle));
            comm.Parameters.Add(new SqlParameter("@numeroCalle", cvm.cliente.NumeroCalle));
            comm.Parameters.Add(new SqlParameter("@idUser", idUser));


            comm.ExecuteNonQuery();

            conn.Close();
        }




        public void EditarCliente(ClienteViewModel cvm)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("exec procedimientoUpdate3 @idLocalidad,@calle,@numeroCalle,@codCliente,@email,@telFijo,@celular", conn);
            comm.Parameters.Add(new SqlParameter("@idLocalidad",cvm.cliente.IdLocalidad ));
            comm.Parameters.Add(new SqlParameter("@calle", cvm.cliente.Calle));
            comm.Parameters.Add(new SqlParameter("@numeroCalle", cvm.cliente.NumeroCalle));
            comm.Parameters.Add(new SqlParameter("@codCliente", cvm.cliente.CodCliente));           
            comm.Parameters.Add(new SqlParameter("@email", cvm.cliente.Email));
            comm.Parameters.Add(new SqlParameter("@telFijo", cvm.cliente.TelFijo));
            comm.Parameters.Add(new SqlParameter("@celular", cvm.cliente.Celular));         


            comm.ExecuteNonQuery();
            conn.Close();
        }



        public List<TipoSexo> ObtenerSexos()
        {
            List<TipoSexo> sexos = new List<TipoSexo>();

            conn.Open();

            SqlCommand comm = new SqlCommand("Select * from tipoSexo tp", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                sexos.Add(new TipoSexo
                {
                    IdTipoSexo = dr.GetInt32(0),
                    Descripcion = dr.GetString(1)

                });
            }

            conn.Close();
            return sexos;
        }

        public List<Cliente> ClientesUsers()
        {
            List<Cliente> clientesUsers = new List<Cliente>();

            conn.Open();

            SqlCommand comm = new SqlCommand("select idUser from cliente where idUser is not null", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                clientesUsers.Add(new Cliente
                {
                    CodUser= dr.GetString(0)
                
                });
            }

            conn.Close();
            return clientesUsers;

        }


    }
}
