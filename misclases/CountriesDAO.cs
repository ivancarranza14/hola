using Microsoft.Data.SqlClient;
using misclases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace claseLogica
{
    public class CountriesDAO : Conexion
    {
        public List<Countries> mostrarcountries()
        {
            List<Countries> list = new List<Countries>();
            
            
            using (SqlConnection conectar = obtenerConexion())
            { 
                conectar.Open();
                string query = "SELECT ID, Name FROM Countries";

                using (SqlCommand comando = new SqlCommand(query, conectar))
                {
                    comando.CommandType = CommandType.Text;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Countries country = new Countries
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Name = reader["Name"].ToString()

                            };
                            list.Add(country);
                        }

                    }
                }

            }
            return list;
            
        }
    }
}
