using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace claseLogica
{
    public abstract class Conexion
    {
        private readonly string cadenaConexion;
        public Conexion()
        {
            cadenaConexion= ConfigurationManager.ConnectionStrings["MiconfigSql"].ConnectionString;
        }

        protected SqlConnection obtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
