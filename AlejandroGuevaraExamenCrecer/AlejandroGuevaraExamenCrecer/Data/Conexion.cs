using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroGuevaraExamenCrecer.Data
{
    public class Conexion
    {
        #region "PATRON SINGLETON"

        private static Conexion conexion = null;
        private Conexion() { }
        public static Conexion getInstance()
        {
            if (conexion == null)
            {
                conexion = new Conexion();
            }

            return conexion;
        }

        #endregion


        public SqlConnection ConexionBD()
        {
            string server = "agdevcom_examenCrecer";
            string DB = "agdevcom_examenCrecer";
            string user = "agdevcom_sistemas";
            string pass = "Vp299&tc";

            String cadenaConexion = $"Data Source={server};Initial Catalog={DB};Persist Security Info=True;User ID={user};Password={pass};";
            SqlConnection conSQL = new SqlConnection(cadenaConexion);

            return conSQL;
        }
    }
}
