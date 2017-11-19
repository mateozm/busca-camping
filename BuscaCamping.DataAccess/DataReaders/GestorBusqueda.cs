using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.ViewModels;
using System.Data;

namespace BuscaCamping.DataAccess.DataReaders
{
    public class GestorBusqueda
    {
        public List<Camping> BuscarPorParametros(string nombre, int[]selected,int total)
        {
            List<Camping> listaCamping = new List<Camping>();

            using (SqlConnection conn = new SqlConnection("Data Source=MATEO\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=BuscaCamping"))
            {
                conn.Open();
                // TODO: Mejorar query! SQL Injection!!
                string query = "select c.idCamping,c.nombreCamping,c.cantParcelas," +
                                "c.calle,c.numeroCalle,dc.email,dc.telFijo,dc.celular,c.idDatosCamping," +
                                "c.idLocalidad,l.idDepartamento,d.idProvincia," +
                                "l.nombreLocalidad, d.nombreDepartamento, p.nombreProvincia " +
                                "from Camping c join DatosCamping dc on dc.idDatosCamping = c.idDatosCamping join Localidad l on c.idLocalidad = l.idLocalidad " +
                                "join Departamento d on d.idDepartamento = l.idDepartamento join Provincia p on p.idProvincia = d.idProvincia " +
                                "join ServicioPorCamping sc on sc.idCamping = c.idCamping " +
                                "where (p.nombreProvincia = '" + nombre + "' or d.nombreDepartamento = '" + nombre + "' or l.nombreLocalidad = '" + nombre + "') " +
                                "and sc.idServicio in(" + PrepareIds(selected) + ") " +
                                "group by c.idCamping,c.nombreCamping,c.cantParcelas,c.calle,c.numeroCalle,dc.email,dc.telFijo,dc.celular,c.idDatosCamping ,c.idLocalidad,l.idDepartamento,d.idProvincia, " +
                                "l.nombreLocalidad, d.nombreDepartamento, p.nombreProvincia " +
                                "having count(distinct sc.idServicio) = " + total;

                SqlCommand comm = new SqlCommand(query, conn);
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
                        Email = dr.GetString(5),
                        TelFijo = dr.GetInt32(6),
                        Celular = dr.GetInt32(7),
                        IdDatosCamping = dr.GetInt32(8),
                        IdLocalidad = dr.GetInt32(9),
                        IdDepartamento = dr.GetInt32(10),
                        IdProvincia = dr.GetInt32(11),
                        NombreLocalidad = dr.GetString(12),
                        NombreDepartamento = dr.GetString(13),
                        NombreProvincia = dr.GetString(14)
                    });
                }
            }

            return listaCamping;
        }

        private string PrepareIds(int[] selected)
        {
            StringBuilder b = new StringBuilder();
            foreach (int i in selected) {
                b.Append(i + ",");
            }

            b.Remove(b.Length - 1, 1);

            return b.ToString();
        }
    }
}
