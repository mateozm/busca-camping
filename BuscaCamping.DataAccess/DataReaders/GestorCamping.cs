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
   public class GestorCamping
    {
        SqlConnection conn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping");

        public List<Camping> ObtenerListaCamping()
        {
            List<Camping> listaCamping = new List<Camping>();

            conn.Open();

            SqlCommand comm = new SqlCommand("select c.idCamping,c.nombreCamping,c.cantParcelas,c.calle,c.numeroCalle,c.idLocalidad,dc.email,dc.telFijo,dc.celular, l.nombreLocalidad, d.nombreDepartamento, p.nombreProvincia from Camping c join DatosCamping dc on dc.idDatosCamping=c.idDatosCamping join Localidad l on c.idLocalidad=l.idLocalidad join Departamento d on d.idDepartamento=l.idDepartamento join Provincia p on p.idProvincia=d.idProvincia", conn);
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                listaCamping.Add(new Camping
                {
                    IdCamping = dr.GetInt32(0),
                    NombreCamping = dr.GetString(1),
                    CantParcelas = dr.GetInt32(2),
                    Calle = dr.GetString(3),
                    NumeroCalle = dr.GetInt32(4),
                    IdLocalidad = dr.GetInt32(5),
                    Email = dr.GetString(6),
                    TelFijo = dr.GetInt32(7),
                    Celular = dr.GetInt32(8),
                    NombreLocalidad = dr.GetString(9),
                    NombreDepartamento = dr.GetString(10),
                    NombreProvincia = dr.GetString(11)                    
                    
                });
            }

            conn.Close();
            return listaCamping;
        }

        public void EliminarCamping(int id)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("DELETE from Camping WHERE idCamping = @id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));

            comm.ExecuteNonQuery();
            conn.Close();
        }

        public Camping ObtenerCamping(int id)
        {
            Camping c = null;
            conn.Open();

            SqlCommand comm = new SqlCommand("select c.idCamping,c.nombreCamping,c.cantParcelas,c.calle,c.numeroCalle,dc.email,dc.telFijo,dc.celular,c.idDatosCamping ,c.idLocalidad,l.idDepartamento,d.idProvincia,  l.nombreLocalidad, d.nombreDepartamento, p.nombreProvincia from Camping c join DatosCamping dc on dc.idDatosCamping=c.idDatosCamping join Localidad l on c.idLocalidad=l.idLocalidad join Departamento d on d.idDepartamento=l.idDepartamento join Provincia p on p.idProvincia=d.idProvincia where idCamping = @id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            if (dr.Read())
            {
                int IdCamping = dr.GetInt32(0);
                string NombreCamping = dr.GetString(1);
                int CantParcelas = dr.GetInt32(2);
                string Calle = dr.GetString(3);
                int NumeroCalle = dr.GetInt32(4);                               
                string Email = dr.GetString(5);
                int TelFijo = dr.GetInt32(6);
                int Celular = dr.GetInt32(7);
                int IdDatosCamping = dr.GetInt32(8);
                int IdLocalidad = dr.GetInt32(9);
                int IdDepartamento = dr.GetInt32(10);
                int IdProvincia = dr.GetInt32(11);
                string NombreLocalidad = dr.GetString(12);
                string NombreDepartamento = dr.GetString(13);
                string NombreProvincia = dr.GetString(14);

                c = new Camping(IdCamping, NombreCamping, CantParcelas, Calle, NumeroCalle, Email, TelFijo, Celular, IdDatosCamping, IdLocalidad, IdDepartamento, IdProvincia, NombreLocalidad, NombreDepartamento, NombreProvincia);
            }

            conn.Close();
            return c;
        }



        public void AgregarCamping(CampingViewModel cvm)
        {
            conn.Open();            

            SqlCommand comm = new SqlCommand("exec insertCamping9 @email,@telFijo,@celular,@nombreCamping,@cantParcelas,@calle,@numeroCalle,@idLocalidad", conn);
            comm.Parameters.Add(new SqlParameter("@email", cvm.camping.Email));
            comm.Parameters.Add(new SqlParameter("@telFijo", cvm.camping.TelFijo));
            comm.Parameters.Add(new SqlParameter("@celular", cvm.camping.Celular));            
            comm.Parameters.Add(new SqlParameter("@nombreCamping", cvm.camping.NombreCamping));
            comm.Parameters.Add(new SqlParameter("@cantParcelas", cvm.camping.CantParcelas));
            comm.Parameters.Add(new SqlParameter("@calle", cvm.camping.Calle));
            comm.Parameters.Add(new SqlParameter("@numeroCalle", cvm.camping.NumeroCalle));
            comm.Parameters.Add(new SqlParameter("@idLocalidad", cvm.camping.IdLocalidad));

            comm.ExecuteNonQuery();

            conn.Close();
        }




        public void EditarCamping(CampingViewModel cvm)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("exec procedimientoUpdate3 @idLocalidad,@calle,@numeroCalle,@codCliente,@email,@telFijo,@celular", conn);
            comm.Parameters.Add(new SqlParameter("@idLocalidad", cvm.camping.IdLocalidad));
            comm.Parameters.Add(new SqlParameter("@calle", cvm.camping.Calle));
            comm.Parameters.Add(new SqlParameter("@numeroCalle", cvm.camping.NumeroCalle));
            comm.Parameters.Add(new SqlParameter("@codCliente", cvm.camping.IdCamping));
            comm.Parameters.Add(new SqlParameter("@email", cvm.camping.Email));
            comm.Parameters.Add(new SqlParameter("@telFijo", cvm.camping.TelFijo));
            comm.Parameters.Add(new SqlParameter("@celular", cvm.camping.Celular));


            comm.ExecuteNonQuery();
            conn.Close();
        }



    }

   
}
