using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AlejandroGuevaraExamenCrecer.Models;

namespace AlejandroGuevaraExamenCrecer.Data
{
    public class DataDiagnostico
    {
        public bool NuevoDiagnostico(ModelDiagnostico obj)
        {
            bool resp = false;
            SqlConnection conexion = null;
            SqlCommand cmd = null;

            conexion = Conexion.getInstance().ConexionBD();
            cmd = new SqlCommand("sp_diagnostico", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@paciente", obj.paciente);
            cmd.Parameters.AddWithValue("@medico", obj.medico);
            cmd.Parameters.AddWithValue("@diagnostico", obj.diagnostico);
            cmd.Parameters.AddWithValue("@receta", obj.receta);
            cmd.Parameters.AddWithValue("@fechaconsulta", obj.fechaconsulta);
            cmd.Parameters.AddWithValue("@estado", 1);


            try
            {
                cmd.ExecuteNonQuery();
                resp = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            conexion.Close();
            return resp;
        }
    }
}
