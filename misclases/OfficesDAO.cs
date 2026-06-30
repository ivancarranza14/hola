using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using misclases;
namespace claseLogica
{

    public class OfficesDAO : Conexion
    {
        public List<Offices> mostrarOffices()
        {
            List<Offices> lista_office = new List<Offices>();

            using (SqlConnection conectarof = obtenerConexion())
            {
                conectarof.Open();
                string consulta = "SELECT Offices.ID, Countries.Name AS CountryName, Offices.Title, Offices.Phone, Offices.Contact " +
                                  "FROM Offices JOIN Countries ON Offices.CountryID = Countries.ID;";
                using (SqlCommand comandoof = new SqlCommand(consulta, conectarof))
                {
                    comandoof.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader veroffices = comandoof.ExecuteReader())
                    {
                        while (veroffices.Read())
                        {
                            Offices oficces = new Offices()
                            {
                                ID = Convert.ToInt32(veroffices["ID"]),
                                Name = veroffices["CountryName"].ToString(),
                                Title = veroffices["Title"].ToString(),
                                Phone = veroffices["Phone"].ToString(),
                                Contact = veroffices["Contact"].ToString(),
                            };
                            lista_office.Add(oficces);
                        }
                    }
                }
            }

            return lista_office;
        }
    }
}

