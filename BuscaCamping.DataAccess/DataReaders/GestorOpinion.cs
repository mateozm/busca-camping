using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCamping.DataAccess.DataReaders
{
    public class GestorOpinion
    {
        SqlConnection conn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping");

        public List<Opinion> ObtenerOpinionesPorCamping(int id)
        {
            List<Opinion> opiniones = new List<Opinion>();

            conn.Open();

            SqlCommand comm = new SqlCommand("select o.idOpinion, o.idCamping,c.nombreCamping, o.texto,o.idUser,o.calificacion from Opinion o join camping c on c.idCamping=o.idCamping where o.idCamping=@id order by o.calificacion desc ", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                opiniones.Add(new Opinion
                {
                    IdOpinion = dr.GetInt32(0),
                    IdCamping=dr.GetInt32(1),
                    NombreCamping=dr.GetString(2),
                    Texto=dr.GetString(3),
                    IdUser=dr.GetString(4),
                    Calificacion=dr.GetInt32(5)

                });
            }

            conn.Close();
            return opiniones;
        }

        public void AgregarOpinion(OpinionViewModel ovm, string id)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("insert into opinion(idCamping,texto,idUser,calificacion)values(@idCamping,@texto,@idUser,@calificacion) ", conn);
            comm.Parameters.Add(new SqlParameter("@idCamping", ovm.Camping.IdCamping));
            comm.Parameters.Add(new SqlParameter("@texto", ovm.Opinion.Texto));
            comm.Parameters.Add(new SqlParameter("@idUser", id));
            comm.Parameters.Add(new SqlParameter("@calificacion", ovm.Opinion.Calificacion));

            comm.ExecuteNonQuery();

            conn.Close();
        }

        public void EliminarOpinion(int id)
        {
            conn.Open();

            SqlCommand comm = new SqlCommand("DELETE from opinion WHERE idOpinion = @id", conn);
            comm.Parameters.Add(new SqlParameter("@id", id));

            comm.ExecuteNonQuery();
            conn.Close();
        }

    }
}
