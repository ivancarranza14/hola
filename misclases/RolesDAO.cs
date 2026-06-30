using Microsoft.Data.SqlClient;
using misclases;
using System;
using System.Collections.Generic;
using System.Text;

namespace claseLogica
{
    public class RolesDAO: Conexion
    {
        public List<Roles> mostrarRoles()
        {
            List<Roles> lista_roles = new List<Roles>();

            using (SqlConnection conexionRol = obtenerConexion())
            {
                conexionRol.Open();
                string consulta = "select * from Roles";
                using (SqlCommand comandoRol = new SqlCommand(consulta, conexionRol))
                {

                    comandoRol.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader verRoles = comandoRol.ExecuteReader())
                    {
                        while (verRoles.Read())
                        {
                            Roles roles = new Roles()
                            {
                                Title = verRoles["Title"].ToString(),
                                ID = Convert.ToInt32(verRoles["ID"]),

                            };
                            lista_roles.Add(roles);

                        }




                    }


                }
            }

            return lista_roles;
        }
    }
}

